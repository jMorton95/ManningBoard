using Microsoft.AspNetCore.Mvc;
using ManningApi.Models;
using ManningApi.Services.Interfaces;
using ManningApi.Services;

namespace ManningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpStationController : ControllerBase
    {
        private readonly ILineService _lineService;
        public OpStationController(ILineService lineService)
        {
            _lineService = lineService;
        }
        [HttpGet]
      public async Task<ActionResult<OpStation>> GetOpStationById(int id) => await _lineService.GetOpStationById(id);
    }
}
