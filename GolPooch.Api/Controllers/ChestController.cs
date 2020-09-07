using Microsoft.AspNetCore.Mvc;
using GolPooch.Service.Interfaces;

namespace GolPooch.Api.Controllers
{
    public class ChestController : Controller
    {
        private IChestService _chestService { get; set; }

        public ChestController(IChestService chestService)
        {
            _chestService = chestService;
        }

        [HttpGet]
        public JsonResult All()
            => Json(_chestService.GetAllAvailable());
    }
}