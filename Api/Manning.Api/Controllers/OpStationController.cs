using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Services.Interfaces;
using Manning.Api.Services;
using Manning.Api.Models;

namespace Manning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpStationController : ControllerBase
    {
        private readonly ILineService _lineService;
        private readonly IOpStationService _opStationService;
        public OpStationController(ILineService lineService, IOpStationService opStationService)
        {
            _lineService = lineService;
            _opStationService = opStationService;
        }
        [HttpGet]
        public async Task<ActionResult<Station>> GetOpStationById(int id) => await _lineService.GetOpStationById(id);
        [HttpPost]
        public ActionResult AssignOperatorToOpstation([FromBody] OperatorAndStationIdDTO dto)
        {
          return Ok();
        }
    }
}
