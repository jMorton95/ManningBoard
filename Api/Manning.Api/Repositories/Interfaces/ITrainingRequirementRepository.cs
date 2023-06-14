using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface ITrainingRequirementRepository : IBaseRepository<TrainingRequirement>
    {
        Task<TrainingRequirement?> GetTrainingRequirementByIDAsync(int ID);
        Task<List<TrainingRequirement>> GetTrainingRequirementsByStationId(int ID);
        Task<TrainingRequirement> AddNewPrerequisite(TrainingRequirement newRequirement);
    }
}
