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
        public TestController(IOperatorCompletedTrainingRepository _operatorCompletedTrainingRepository)
        {
            operatorCompletedTrainingRepository = _operatorCompletedTrainingRepository;
        }
        [HttpGet("{operatorID}")]
        public async Task<List<OperatorCompletedTraining>> GetTraining(int operatorID)
        {
          return await operatorCompletedTrainingRepository.GetOperatorCompletedTraining(operatorID);
        }
    }
}
