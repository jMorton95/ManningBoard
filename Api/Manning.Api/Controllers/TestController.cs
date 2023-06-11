using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;
using Manning.Api.ViewModels;


namespace Manning.Api.Controllers
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
        public Task<List<OperatorAndTraining>> GetOperatorsAndTraining()
        {
            return opStationService.GetAllOperatorsAndTraining();
        }
    }
}
