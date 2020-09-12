using Elk.Core;
using GolPooch.Domain.Entity;
using System.Threading.Tasks;

namespace GolPooch.Service.Interfaces
{
    public interface IVerificationCodeService
    {
        /// <summary>
        /// Get verification Code + resend code again
        /// </summary>
        /// <param name="mobileNumber">MobileNumber was entered by user</param>
        /// <param name="osType">this field is for detecting which message we should send</param>
        /// <returns>return VerificationId for Verify</returns>
        Task<IResponse<int>> GetCodeAsync(long mobileNumber, OsType osType);

        /// <summary>
        /// verify last Code and register user with mobilenumber that user entered
        /// </summary>
        /// <param name="verificationCodeId">the verification primaryKey for finding row</param>
        /// <param name="code">the digit code that was entered by </param>
        /// <returns>User Model</returns>
        Task<IResponse<User>> VerifyCodeAsync(int verificationCodeId, int pinCode);
    }
}