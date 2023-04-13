using ReactManningPoCAPI.Models;

namespace ReactManningPoCAPI.Repositories.Interfaces
{
    public interface ITrainingRequirementRepository
    {
        Task<TrainingRequirement?> GetTrainingRequirementByIDAsync(int ID);
        Task<TrainingRequirement> AddNewPrerequisite(TrainingRequirement newRequirement);
    }
}
