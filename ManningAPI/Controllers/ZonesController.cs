/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Services.Interfaces;

namespace ReactManningPoCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        private readonly ILineService _lineService;
        public ZonesController(ILineService lineService)
        {
            _lineService = lineService;
        }
        [HttpGet]
        public async Task<List<Zone>> GetAllZones() => await _lineService.GetAllZones();
    }
}
*/