using ManningApi.Models;

namespace ManningApi.Repositories.Interfaces
{
    public interface ITrainingRequirementRepository
    {
        Task<TrainingRequirement?> GetTrainingRequirementByIDAsync(int ID);
        Task<TrainingRequirement> AddNewPrerequisite(TrainingRequirement newRequirement);
    }
}
