using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Services.Interfaces;
using Manning.Api.Services;
using Manning.Api.Models;

namespace Manning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly ILineService _lineService;
        private readonly IStationService _stationService;
        public StationController(ILineService lineService, IStationService stationService)
        {
            _lineService = lineService;
            _stationService = stationService;
        }
        [HttpGet]
        public async Task<ActionResult<Station>> GetStationById(int id) => await _lineService.GetStationById(id);

        [HttpPost("AddOperatorToStation")]
        public async Task<ActionResult> AddOperatorToStation([FromBody] OperatorAndStationIdDTO dto)
        {
          var station = await _stationService.AddOperatorToStation(dto);
          return Ok();
        }

        [HttpPost("RemoveOperatorFromStation")]
        public async Task<ActionResult> RemoveOperatorFromStation([FromBody] OperatorAndStationIdDTO dto)
        {
          var station = await _stationService.RemoveOperatorFromStation(dto);
          return Ok();
        }
    }
}
