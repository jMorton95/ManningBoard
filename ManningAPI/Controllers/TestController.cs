using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ManningApi.Models;
using ManningApi.Repositories.Interfaces;
using ManningApi.Services.Interfaces;
using ManningApi.ViewModels;


namespace ManningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IOperatorCompletedTrainingRepository operatorCompletedTrainingRepository;
        private readonly IOpStationService opStationService;
        public TestController(IOperatorCompletedTrainingRepository _operatorCompletedTrainingRepository, IOpStationService _opStationService)
        {
            operatorCompletedTrainingRepository = _operatorCompletedTrainingRepository;
            opStationService = _opStationService;
        }
        [HttpGet("{operatorID}")]
        public List<OperatorCompletedTraining> GetTraining(int operatorID)
        {
            return operatorCompletedTrainingRepository.GetOperatorCompletedTraining(operatorID);
        }
        [HttpGet]
        public List<OperatorAndTraining> GetOperatorsAndTraining()
        {
            return opStationService.GetAllOperatorsAndTraining();
        }
    }
}
