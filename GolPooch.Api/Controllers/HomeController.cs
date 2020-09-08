using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GolPooch.Api.Controllers
{
    [AuthorizeFilter, Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index() => Ok("Wellcome to GolYaPooch Api ...");
    }
}