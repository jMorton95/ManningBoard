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
        public async Task<List<Zone>> GetAllZonesAndOpStations() => await _lineService.GetAllZonesAndOpStations();
        [HttpGet("OpStations")]
        public async Task<List<OpStation>> GetAllOpStations() => await _lineService.GetAllOpStations();
    }
}
