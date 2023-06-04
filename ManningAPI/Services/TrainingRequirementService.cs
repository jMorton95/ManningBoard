using ManningApi.Models;
using ManningApi.Repositories.Interfaces;
using ManningApi.Services.Interfaces;

namespace ManningApi.Services
{
    public class TrainingRequirementService : ITrainingRequirementService
    {
        private readonly ITrainingRequirementRepository _trainingRequirementRepository;
        public TrainingRequirementService(ITrainingRequirementRepository trainingRequirementRepository)
        {
            _trainingRequirementRepository = trainingRequirementRepository;
        }

        public async Task<TrainingRequirement> AddNewPrerequisite(string requirementDescription, int opstationID) 
        {
            TrainingRequirement newRequirement = new TrainingRequirement { RequirementDescription = requirementDescription, OpStationID = opstationID, TrainingRequirementTypeId = 1 };
            return await _trainingRequirementRepository.AddNewPrerequisite(newRequirement);
        } 
        
    }
}
