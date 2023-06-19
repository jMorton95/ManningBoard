using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Services.Interfaces;
using Manning.Api.Services;
using Manning.Api.Models;
using Microsoft.AspNetCore.DataProtection;

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

        [HttpGet("{stationID}")]
        public async Task<ActionResult<StationAssignableOperatorsDTO>> GetAssignableOperators(int stationID) => Ok(await _stationService.GetAssignableOperatorsGrouped(stationID));          

        [HttpPost("AddOperatorToStation")]
        public async Task<ActionResult> AddOperatorToStation([FromBody] OperatorAndStationIdDTO dto)
        {
          //SignalR Entry Point.
          StationStateModel stationFromDTO = new(){StationID = dto.StationID, OperatorID = dto.OperatorID};
          if (!await _stationService.CheckOperatorIsTrainedOnStation(stationFromDTO))
          {
            return Ok(null);
          }
          await _stationService.AddOperatorToStation(stationFromDTO);
          return Ok("Added");
        }

        [HttpPost("RemoveOperatorFromStation")]
        public async Task<ActionResult> RemoveOperatorFromStation([FromBody] OperatorAndStationIdDTO dto)
        {
          //SignalR Entry Point.
          await _stationService.RemoveOperatorFromStation(new StationStateModel {StationID = dto.StationID, OperatorID = dto.OperatorID});
          return Ok();
        }
    }
}
