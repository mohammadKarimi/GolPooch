using Elk.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GolPooch.Service.Interfaces;

namespace GolPooch.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class NotificationController : Controller
    {
        private INotificationService _notificationService { get; set; }

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<JsonResult> AddDeliveryAsync(int userId, int notificationId)
            => Json(await _notificationService.AddDeliveryAsync(userId, notificationId));

        [HttpGet]
        public JsonResult Top(int userId, [FromBody] PagingParameter pagingParameter)
            => Json(_notificationService.GetTopNotifications(userId, pagingParameter));

        [HttpPost]
        public JsonResult Read(int notificationId)
            => Json(_notificationService.ReadAsync(notificationId));
    }
}