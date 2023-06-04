using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Repositories.Interfaces;
using ReactManningPoCAPI.Services.Interfaces;
using System.Data;

namespace ReactManningPoCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TrainingRequirementController : ControllerBase
    {
        private readonly ITrainingRequirementService _trainingRequirementService;
        private readonly ITrainingRequirementRepository _trainingRequirementRepository;
        public TrainingRequirementController(ITrainingRequirementService trainingRequirementService, ITrainingRequirementRepository trainingRequirementRepository)
        {
            _trainingRequirementService = trainingRequirementService;
            _trainingRequirementRepository = trainingRequirementRepository;
        }

        [HttpPost]
        public async Task<TrainingRequirement> CreateNewPrerequisite(string requirementDescription, int opstationID)
        {
            return await _trainingRequirementService.AddNewPrerequisite(requirementDescription, opstationID);
        }
        [HttpGet("{ID}")]
        public async Task<ActionResult<TrainingRequirement>> GetByIdTask(int ID)
        {
           var trainingRequirement = await _trainingRequirementRepository.GetTrainingRequirementByIDAsync(ID);
            if (trainingRequirement == null)
            {
                return NotFound();
            }
            return Ok(trainingRequirement);
        }
    }
}
