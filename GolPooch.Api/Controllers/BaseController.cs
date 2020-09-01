using Microsoft.AspNetCore.Mvc;

namespace GolPooch.Api.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Return Region Enum in key,Value model
        /// result of this method must be cached.
        /// </summary>
        /// <returns>List of Key,Value Object</returns>
        public IActionResult Regions() => Ok();

    }
}
