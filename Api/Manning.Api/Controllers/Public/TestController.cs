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
        private readonly IWorkingDayHistoryRepository workingDayHistoryRepository;
        private readonly IStationStateRepository _stationStateRepository;
        public TestController(
            IStationService _stationService,
            IOperatorService _operatorService,
            ILineService _lineService,
            IWorkingDayHistoryRepository _workingDayHistory,
            IStationStateRepository stationStateRepository

        )
        {
            stationService = _stationService;
            operatorService = _operatorService;
            lineService = _lineService;
            workingDayHistoryRepository = _workingDayHistory;
            _stationStateRepository = stationStateRepository;
        }

        [HttpGet("GetStuff")]
        public async Task<IActionResult> GetStuff()
        {
            var shift = await _stationStateRepository.GetAll();
            await workingDayHistoryRepository.SaveCurrentShift(shift, "Test Shift");
            var memes = await workingDayHistoryRepository.GetAll();
            return Ok(memes);
        }
        [HttpGet("AllZones")]
        public async Task<List<Zone>> AllZones() => await lineService.GetAllZones();

    }
}
