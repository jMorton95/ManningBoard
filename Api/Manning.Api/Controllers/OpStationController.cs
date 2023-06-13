using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models;
using Manning.Api.Services.Interfaces;
using Manning.Api.Services;

namespace Manning.Api.Controllers
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
