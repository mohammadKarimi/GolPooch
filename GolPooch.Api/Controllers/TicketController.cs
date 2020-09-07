using Elk.Core;
using GolPooch.Domain.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GolPooch.Service.Interfaces;

namespace GolPooch.Api.Controllers
{
    public class TicketController : Controller
    {
        private ITicketService _ticketService { get; set; }

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<JsonResult> AddAsync([FromBody] Ticket ticket)
            => Json(await _ticketService.AddAsync(ticket));

        [HttpGet]
        public JsonResult Top(int userId, [FromBody] PagingParameter pagingParameter)
            => Json(_ticketService.Get(userId, pagingParameter));

        [HttpGet]
        public async Task<JsonResult> Get([FromBody] int ticketId)
            => Json(await _ticketService.Get(ticketId));

        [HttpPost]
        public async Task<JsonResult> Read([FromBody] int ticketId)
            => Json(await _ticketService.Read(ticketId));
    }
}