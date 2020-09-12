using GolPooch.Domain.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GolPooch.Service.Interfaces;

namespace GolPooch.Api.Controllers
{
    [AuthorizeFilter, Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private IUserService _userService { get; set; }

        public UserController(IUserService userService)
            => _userService = userService;

        [HttpPost]
        public async Task<JsonResult> UpdateProfileAsync([FromBody] User user)
            => Json(await _userService.UpdateProfileAsync(user));

        [HttpPost]
        public async Task<JsonResult> UploadAwatarAsync(int userId, string fileExtension, byte[] fileBytes)
            => Json(await _userService.UploadAwatarAsync(userId, fileExtension, fileBytes));
    }
}