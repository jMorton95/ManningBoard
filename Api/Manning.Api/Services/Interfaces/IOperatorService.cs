using Manning.Api.Models;

namespace Manning.Api.Services
{
  public interface IOperatorService
  {
    Task<List<TrainingRequirement>> GetDetailedTrainingRequirementsForOperator(int operatorID);
    Task<List<TrainingRequirement>> GetIncompleteTrainingForOperator(int operatorID);
  }
}