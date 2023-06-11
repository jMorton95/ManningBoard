using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface ITrainingRequirementRepository
    {
        Task<TrainingRequirement?> GetTrainingRequirementByIDAsync(int ID);
        Task<TrainingRequirement> AddNewPrerequisite(TrainingRequirement newRequirement);
    }
}
