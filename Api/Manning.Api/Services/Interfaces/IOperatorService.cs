using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Services
{
  public interface IOperatorService
  {
    Task<List<Operator>> GetAllOperators();
    Task<Operator> GetOperatorByID(int operatorID);
    Task<List<OperatorAndAvatarDTO>> GetAllOperatorsAndAvatars();
    Task<OperatorAndAvatarDTO> GetOperatorAndAvatarByID(int operatorID);
    Task<List<TrainingRequirement>> GetDetailedTrainingRequirementsForOperator(int operatorID);
    Task<List<TrainingRequirement>> GetIncompleteTrainingForOperator(int operatorID);
  }
}