using GolPooch.Domain.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GolPooch.Service.Interfaces;

namespace GolPooch.Api.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService { get; set; }
        private IVerificationCodeService _verificationCodeService { get; }

        public UserController(IUserService userService, IVerificationCodeService verificationCodeService)
        {
            _userService = userService;
            _verificationCodeService = verificationCodeService;
        }

        [HttpGet]
        public async Task<JsonResult> GetCodeAsync([FromBody] long mobileNumber)
            => Json(await _verificationCodeService.GetCodeAsync(mobileNumber, OsType.Android));

        [HttpPost]
        public async Task<JsonResult> VerifyCodeAsync([FromBody] int verificationCodeId, int pinCode)
            => Json(await _verificationCodeService.VerifyCodeAsync(verificationCodeId, pinCode));

        [HttpPost]
        public async Task<JsonResult> UpdateProfileAsync([FromBody] User user)
            => Json(await _userService.UpdateProfileAsync(user));

        [HttpPost]
        public async Task<JsonResult> UploadAwatarAsync(int userId, [FromBody] string fileExtension, [FromBody] byte[] fileBytes)
            => Json(await _userService.UploadAwatarAsync(userId, fileExtension, fileBytes));
    }
}