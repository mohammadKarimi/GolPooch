using System;
using Elk.Core;
using GolPooch.SmsGateway;
using GolPooch.DataAccess.Ef;
using System.Threading.Tasks;
using GolPooch.Domain.Entity;
using GolPooch.Service.Resourses;
using GolPooch.Service.Interfaces;

namespace GolPooch.Service.Implements
{
    public class VerificationCodeService : IVerificationCodeService
    {
        private ISmsGatway _smsGatway { get; set; }
        private AppUnitOfWork _appUow { get; set; }

        public VerificationCodeService(AppUnitOfWork appUnitOfWork, ISmsGatway smsGatway)
        {
            _smsGatway = smsGatway;
            _appUow = appUnitOfWork;
        }

        public async Task<IResponse<int>> GetCodeAsync(long mobileNumber, OsType osType)
        {
            var response = new Response<int> { IsSuccessful = true, Message = ServiceMessage.Success };
            try
            {
                var randomPinCode = Randomizer.GetRandomInteger(5);
                var text = "برای ورود به اپ کد زیر را وارد نمایید." + Environment.NewLine +
                    $"code = {randomPinCode}";

                var verificationCode = new VerificationCode
                {
                    IsUsed = false,
                    PinCode = randomPinCode,
                    MobileNumber = mobileNumber,
                    ExpirationTime = DateTime.Now.AddMinutes(5)
                };
                await _appUow.VerificationCodeRepo.AddAsync(verificationCode);

                var saveResult = await _appUow.ElkSaveChangesAsync();
                if (saveResult.IsSuccessful)
                {
                    var sendResult = await _smsGatway.SendAsync(mobileNumber.ToNormalNumber(), text);
                    if (sendResult.IsSuccessful && sendResult.Result) response.Result = verificationCode.VerificationCodeId;
                    else
                    {
                        response.IsSuccessful = false;
                        response.Message = sendResult.Message;
                    }
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = saveResult.Message;
                }

                return response;
            }
            catch (Exception e)
            {
                FileLoger.Error(e);
                response.Message = ServiceMessage.Exception;
                return response;
            }
        }

        public async Task<IResponse<User>> VerifyCodeAsync(int verificationCodeId, int pinCode)
        {
            var response = new Response<User>();
            try
            {
                var expiredTime = DateTime.Now;
                var existedPinCode = await _appUow.VerificationCodeRepo.FirstOrDefaultAsync(new QueryFilter<VerificationCode> { Conditions = x => x.VerificationCodeId == verificationCodeId, AsNoTracking = false }); ;
                if (existedPinCode.IsNull()) return new Response<User> { Message = ServiceMessage.InvalidId };
                if (existedPinCode.IsUsed) return new Response<User> { Message = ServiceMessage.UsedPinCode };
                if (existedPinCode.ExpirationTime < expiredTime) return new Response<User> { Message = ServiceMessage.ExpiredPinCode };
                if (existedPinCode.PinCode != pinCode) return new Response<User> { Message = ServiceMessage.InvalidPinCode };

                var newUser = new User
                {
                    MobileNumber = existedPinCode.MobileNumber
                };
                await _appUow.UserRepo.AddAsync(newUser);

                existedPinCode.IsUsed = true;
                existedPinCode.UserId = newUser.UserId;
                _appUow.VerificationCodeRepo.Update(existedPinCode);

                var saveResult = await _appUow.ElkSaveChangesAsync();
                response.Result = saveResult.IsSuccessful ? newUser : null;
                response.IsSuccessful = saveResult.IsSuccessful;
                response.Message = saveResult.Message;
                return response;
            }
            catch (Exception e)
            {
                FileLoger.Error(e);
                response.Message = ServiceMessage.Exception;
                return response;
            }
        }
    }
}