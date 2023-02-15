using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactManningPoCAPI.Services.Interfaces;
using ReactManningPoCAPI.ViewModels;

namespace ReactManningPoCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoaController : ControllerBase
    {
        private readonly IOpStationService _opstationService;
        public SoaController(IOpStationService opStationService)
        {
            _opstationService = opStationService;
        }

        [HttpGet]
        public List<OperatorAndTraining> GetAllOperatorsAndTraining()
        {
            return _opstationService.GetAllOperatorsAndTraining();
        }
        [HttpGet("{opstationID}")]
        public List<OperatorGrouped> GetOperatorTrainingByOpStation(int opstationID) => _opstationService.GetOperatorsGroupedByTraining(opstationID);

    }
}
