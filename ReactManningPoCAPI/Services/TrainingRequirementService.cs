using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Repositories.Interfaces;
using ReactManningPoCAPI.Services.Interfaces;

namespace ReactManningPoCAPI.Services
{
    public class TrainingRequirementService : ITrainingRequirementService
    {
        private readonly ITrainingRequirementRepository _trainingRequirementRepository;
        public TrainingRequirementService(ITrainingRequirementRepository trainingRequirementRepository)
        {
            _trainingRequirementRepository = trainingRequirementRepository;
        }

        public async Task<TrainingRequirement> AddNewPrerequisite(string requirementDescription, int opstationID) => await _trainingRequirementRepository.AddNewPrerequisite(requirementDescription, opstationID);
        
    }
}
