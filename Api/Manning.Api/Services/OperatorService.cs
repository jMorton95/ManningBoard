using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Services
{
  public class OperatorService : IOperatorService
  {
    private readonly ITrainingRequirementRepository _trainingRequirementRepository;
    private readonly IOperatorRepository _operatorRepository;
    private readonly IOperatorCompletedTrainingRepository _operatorCompletedTrainingRepository;
    public OperatorService(ITrainingRequirementRepository trainingRequirementRepository, IOperatorRepository operatorRepository, IOperatorCompletedTrainingRepository operatorCompletedTrainingRepository)
    {
      _trainingRequirementRepository = trainingRequirementRepository;
      _operatorRepository = operatorRepository;
      _operatorCompletedTrainingRepository = operatorCompletedTrainingRepository;
    }
    public async Task<Operator> GetOperatorByID(int operatorID)
    {
      return await _operatorRepository.GetById(operatorID);
    }

    public async Task<List<Operator>> GetAllOperators()
    {
      return await _operatorRepository.GetAll();
    }

    public async Task<List<TrainingRequirement>> GetDetailedTrainingRequirementsForOperator(int operatorID)
    {
      OperatorAndTrainingDTO operatorWithTraining = await _operatorRepository.GroupOperatorWithTraining(operatorID);

      return (operatorWithTraining.TrainingIDs != null && operatorWithTraining.TrainingIDs.Length > 0)
      ? await _trainingRequirementRepository.GetManyById(operatorWithTraining.TrainingIDs)
      : new List<TrainingRequirement>();
    }

    public async Task<List<TrainingRequirement>> GetIncompleteTrainingForOperator(int operatorID)
    {
      List<OperatorCompletedTraining> operatorCompletedTraining = await _operatorCompletedTrainingRepository.GetOperatorCompletedTraining(operatorID);

      if (operatorCompletedTraining.Count < 1)
      {
        return await _trainingRequirementRepository.GetAll();
      }
      
      int[] operatorTrainingIDs = operatorCompletedTraining.Select(x => x.TrainingRequirementID).ToArray();

      return await _trainingRequirementRepository.GetManyByExcludedID(operatorTrainingIDs);
    }

   
  }
}