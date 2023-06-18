using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Services;

namespace Manning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IOperatorCompletedTrainingRepository operatorCompletedTrainingRepository;
        private readonly IStationService stationService;
        private readonly IOperatorService operatorService;
        public TestController(IOperatorCompletedTrainingRepository _operatorCompletedTrainingRepository, IStationService _stationService, IOperatorService _operatorService)
        {
            operatorCompletedTrainingRepository = _operatorCompletedTrainingRepository;
            stationService = _stationService;
            operatorService = _operatorService;

        }
       
        [HttpGet("{operatorID}")]
        public async Task<List<TrainingRequirement>> GetStuff(int operatorID)
        {
            return await operatorService.GetDetailedTrainingRequirementsForOperator(operatorID);
        }

    }
}
