using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models;
using Manning.Api.Services.Interfaces;

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
        public async Task<List<Zone>> GetAllZonesAndStations() => await _lineService.GetAllZonesAndStations();
        [HttpGet("Stations")]
        public async Task<List<Station>> GetAllStations() => await _lineService.GetAllStations();
    }
}
