using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Services.Interfaces;
using Manning.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace Manning.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StationManagementController : ControllerBase
    {
        private readonly IStationService _stationService;
        public StationManagementController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet("{stationID}")]
        public async Task<ActionResult<StationAssignableOperatorsDTO>> GetAssignableOperators(int stationID)
        {
          return Ok(await _stationService.GetAssignableOperatorsGrouped(stationID));
        } 

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
