using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface ITrainingRequirementRepository : IBaseRepository<TrainingRequirement>
    {
      Task<List<TrainingRequirement>> GetTrainingRequirementsByStationId(int ID);
      Task<TrainingRequirement> AddNewPrerequisite(TrainingRequirement newRequirement);
    }
}
