using Elk.Core;
using Elk.AspNetCore;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GolPooch.Service.Interfaces;
using Microsoft.Extensions.Options;

namespace GolPooch.Api.Controllers
{
    [AuthFilter, Route("[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        private IJwtService _jwtService { get; }
        private JwtSettings _jwtSettings { get; }
        private IUserDeviceService _userDeviceService { get; }
        private IAuthenticateService _verificationCodeService { get; }

        public AuthenticationController(IAuthenticateService verificationCodeService,
            IJwtService jwtService, IOptions<JwtSettings> jwtSettings,
            IUserDeviceService userDeviceService)
        {
            _jwtService = jwtService;
            _jwtSettings = jwtSettings.Value;
            _userDeviceService = userDeviceService;
            _verificationCodeService = verificationCodeService;
        }

        [HttpGet]
        public async Task<JsonResult> GetCodeAsync(long mobileNumber)
            => Json(await _verificationCodeService.GetCodeAsync(mobileNumber));

        [HttpPost]
        public async Task<JsonResult> VerifyCodeAsync(int transactionId, int pinCode)
        {
            var response = new Response<JwtToken>();
            var verifyCodeReault = await _verificationCodeService.VerifyCodeAsync(transactionId, pinCode);
            if (verifyCodeReault.IsSuccessful)
            {
                var userClimes = new List<Claim> {
                    new Claim("UserId", verifyCodeReault.Result.UserId.ToString()),
                    new Claim("MobileNumber", verifyCodeReault.Result.MobileNumber.ToString())
                };
                response.Result = _jwtService.CreateToken(userClimes, _jwtSettings);

                await _userDeviceService.AddAsync(HttpContext, verifyCodeReault.Result.MobileNumber);
            }

            response.Message = verifyCodeReault.Message;
            response.IsSuccessful = verifyCodeReault.IsSuccessful;
            return Json(response);
        }
    }
}