using Microsoft.AspNetCore.Mvc;

namespace GolPooch.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => Ok("Hi EveryBody!");
    }
}
