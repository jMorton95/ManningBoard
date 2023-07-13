using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Services.Interfaces;
using Manning.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace Manning.Api.Controllers
{
    //[Authorize(Roles = "Admin")]
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
          //SignalR State Trigger
          StationStateModel stationFromDTO = new(){StationID = dto.StationID, OperatorID = dto.OperatorID, IsTrainee = dto.IsTrainee};
          if (!stationFromDTO.IsTrainee && !await _stationService.CheckOperatorIsTrainedOnStation(stationFromDTO))
          {
            return BadRequest("Operator not trained on Station");
          }
          await _stationService.AddOperatorToStation(stationFromDTO);
          return Ok($"UserID: {dto.OperatorID} assigned to StationID: {dto.StationID}");
        }

        [HttpPost("RemoveOperatorFromStation")]
        public async Task<ActionResult> RemoveOperatorFromStation([FromBody] OperatorAndStationIdDTO dto)
        {
          //SignalR State Trigger
          await _stationService.RemoveOperatorFromStation(new StationStateModel {StationID = dto.StationID, OperatorID = dto.OperatorID});
          return Ok();
        }
    }
}
