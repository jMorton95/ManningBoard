using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;

namespace Manning.Api.Services
{
    public class TrainingRequirementService : ITrainingRequirementService
    {
        private readonly ITrainingRequirementRepository _trainingRequirementRepository;
        public TrainingRequirementService(ITrainingRequirementRepository trainingRequirementRepository)
        {
            _trainingRequirementRepository = trainingRequirementRepository;
        }

        public async Task<TrainingRequirement> AddNewPrerequisite(string requirementDescription, int stationID)
        {
            TrainingRequirement newRequirement = new() { RequirementDescription = requirementDescription, StationID = stationID };
            return await _trainingRequirementRepository.AddNewPrerequisite(newRequirement);
        }

    }
}
