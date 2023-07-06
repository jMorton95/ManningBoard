using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;
using Manning.Api.Services;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IStationService stationService;
        private readonly IOperatorService operatorService;
        private readonly ILineService lineService;
        public TestController(
        IStationService _stationService,
        IOperatorService _operatorService,
        ILineService _lineService
        )
        {
          stationService = _stationService;
          operatorService = _operatorService;
          lineService = _lineService;
        }
       
        [HttpGet("{operatorID}")]
        public async Task<OperatorAndAvatarDTO> GetStuff(int operatorID)
        {
            return await operatorService.GetOperatorAndAvatarByID(operatorID);
        }
        [HttpGet("AllZones")]
        public async Task<List<Zone>> AllZones() => await lineService.GetAllZones();

    }
}
