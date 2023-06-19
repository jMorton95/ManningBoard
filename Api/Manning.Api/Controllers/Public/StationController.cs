using Microsoft.AspNetCore.Mvc;
using Manning.Api.Services.Interfaces;
using Manning.Api.Models;

namespace Manning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly ILineService _lineService;
        public StationController(ILineService lineService)
        {
            _lineService = lineService;
        }
        [HttpGet]
        public async Task<ActionResult<Station>> GetStationById(int id) => await _lineService.GetStationById(id);

    }
}
