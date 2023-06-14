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
        [HttpPost]
        public ActionResult AssignOperatorToOpstation([FromBody] OperatorAndStationIdDTO dto)
        {
          return Ok();
        }
    }
}
