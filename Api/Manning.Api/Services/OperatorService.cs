using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Services
{
  public class OperatorService : IOperatorService
  {
    private readonly ITrainingRequirementRepository _trainingRequirementRepository;
    private readonly IOperatorRepository _operatorRepository;
    public OperatorService(ITrainingRequirementRepository trainingRequirementRepository, IOperatorRepository operatorRepository)
    {
      _trainingRequirementRepository = trainingRequirementRepository;
      _operatorRepository = operatorRepository;
    }
    public async Task<List<TrainingRequirement>> GetDetailedTrainingRequirementsForOperator(int operatorID)
    {
      OperatorAndTrainingDTO operatorWithTraining = await _operatorRepository.GroupOperatorWithTraining(operatorID);

      return (operatorWithTraining.TrainingIDs != null && operatorWithTraining.TrainingIDs.Length > 0)
      ? await _trainingRequirementRepository.GetManyById(operatorWithTraining.TrainingIDs)
      : new List<TrainingRequirement>();
    }
  }
}