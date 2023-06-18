using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface ITrainingRequirementRepository : IBaseRepository<TrainingRequirement>
    {
      Task<List<TrainingRequirement>> GetTrainingRequirementsByStationId(int ID);
      Task<TrainingRequirement> AddNewPrerequisite(TrainingRequirement newRequirement);
      Task<List<TrainingRequirement>> GetDetailedTrainingForOperator(int[] trainingIds);
      Task<List<TrainingRequirement>> GetIncompleteTrainingForOperator(int[] trainingIds);
    }
}
