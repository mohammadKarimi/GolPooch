using GolPooch.Domain.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GolPooch.Service.Interfaces;

namespace GolPooch.Api.Controllers
{
    [AuthFilter, Route("[controller]/[action]")]
    public class Authentication : Controller
    {
        private IVerificationCodeService _verificationCodeService { get; }

        public Authentication(IVerificationCodeService verificationCodeService)
            => _verificationCodeService = verificationCodeService;

        [HttpGet]
        public async Task<JsonResult> GetCodeAsync(long mobileNumber)
            => Json(await _verificationCodeService.GetCodeAsync(mobileNumber, OsType.Android));

        [HttpPost]
        public async Task<JsonResult> VerifyCodeAsync(int verificationCodeId, int pinCode)
            => Json(await _verificationCodeService.VerifyCodeAsync(verificationCodeId, pinCode));
    }
}