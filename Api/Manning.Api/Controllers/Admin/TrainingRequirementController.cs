using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Manning.Api.Models;
using Manning.Api.Services.Interfaces;

namespace Manning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TrainingRequirementController : ControllerBase
    {
        private readonly ITrainingRequirementService _trainingRequirementService;
        public TrainingRequirementController(ITrainingRequirementService trainingRequirementService)
        {
            _trainingRequirementService = trainingRequirementService;
        }

        [HttpPost]
        public async Task<TrainingRequirement> CreateNewPrerequisite(string requirementDescription, int stationID)
        {
            return await _trainingRequirementService.AddNewPrerequisite(requirementDescription, stationID);
        }
    }
}
