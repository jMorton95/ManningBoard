using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IOperatorCompletedTrainingRepository operatorCompletedTrainingRepository;
        private readonly IStationService stationService;
        public TestController(IOperatorCompletedTrainingRepository _operatorCompletedTrainingRepository, IStationService _stationService)
        {
            operatorCompletedTrainingRepository = _operatorCompletedTrainingRepository;
            stationService = _stationService;

        }
        [HttpGet("{stationID}")]
        public async Task<StationAssignableOperatorsDTO> GetTraining(int stationID)
        {
          return await stationService.GetAssignableOperatorsGrouped(stationID);
        }
        [HttpGet()]
        public async Task<List<OperatorAndTrainingDTO>> GetStuff()
        {
            return await stationService.GroupOperatorsWithTraining();
        }

    }
}
