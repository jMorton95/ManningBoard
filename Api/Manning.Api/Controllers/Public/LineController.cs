using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models;
using Manning.Api.Services.Interfaces;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : ControllerBase
    {
        private readonly ILineService _lineService;
        public LineController(ILineService lineService)
        {
            _lineService = lineService;
        }
        [HttpGet]
        public async Task<List<Zone>> GetAllZonesAndStations()
        {
            return await _lineService.GetAllZonesAndStations();
        }
        [HttpGet("Stations")]
        public async Task<List<Station>> GetAllStations() => await _lineService.GetAllStations();
        [HttpGet("GetLineState")]
        public async Task<List<ZoneStateDTO>> GetLineState() => await _lineService.GetLineState();
    }
}
