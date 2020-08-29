using Elk.Core;
using GolPooch.Domain.Entity;
using System;
using System.Threading.Tasks;

namespace GolPooch.Service.Interfaces
{
    public interface IVerificationCodeService
    {
        /// <summary>
        /// Get verification Code
        /// </summary>
        /// <param name="mobileNumber">MobileNumber was entered by user</param>
        /// <param name="osType">this field is for detecting which message we should send</param>
        /// <returns>return VerificationId for Verify</returns>
        Task<IResponse<int>> GetCode(long mobileNumber,OsType osType);

        /// <summary>
        /// Verification Code and register user with mobilenumber that user entered
        /// </summary>
        /// <param name="verificationCodeId">the verification primaryKey for finding row</param>
        /// <param name="code">the digit code that was entered by </param>
        /// <returns>User Id</returns>
        Task<IResponse<Guid>> VerifyCode(int verificationCodeId, int code);
    }
}
