using Microsoft.AspNetCore.Mvc;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Services;
using Unicam.Enterprise.Project.Application.Services.Abstractions;
using Unicam.Enterprise.Project.Application.Models.DTOs;


namespace Unicam.Enterprise.Project.Controllers
{
    public class HistoryController : ControllerBase
    {

        private readonly HistoryService _historyService;
        public HistoryController(HistoryService elem)
        {
            _historyService = elem;
        }


        [HttpGet]
        public IActionResult GetHistory(HistoryDto dto)
        {
            var elem = _historyService.GetOrderHistory(dto.StartDate, dto.EndDate, dto.UserId, dto.userRoleId, dto.pageIndex, dto.pageSize);
            return Ok(elem);
        }
    }
}
