﻿using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
  public class OperatorRepository : BaseRepository<Operator>, IOperatorRepository
    {
      private readonly IOperatorCompletedTrainingRepository _operatorCompletedTrainingRepository;
      public OperatorRepository(ManningDbContext dbContext, IOperatorCompletedTrainingRepository operatorCompletedTrainingRepository) : base(dbContext)
      {
        _operatorCompletedTrainingRepository = operatorCompletedTrainingRepository;
      }

      public async Task<OperatorAndTrainingDTO> GroupOperatorWithTraining(int operatorID)
      {
        List<OperatorCompletedTraining>? allTraining = await _operatorCompletedTrainingRepository.GetAll();

        return new OperatorAndTrainingDTO()
        {
          Operator = await GetById(operatorID),
          TrainingIDs = allTraining.Where(op => op.OperatorID == operatorID).Select(t => t.ID).ToArray()
        };
      }

      public async Task<List<OperatorAndTrainingDTO>> GroupAllOperatorsWithTraining()
      {
        List<Operator>? allOperators = await GetAll();
        List<OperatorCompletedTraining>? allTraining = await _operatorCompletedTrainingRepository.GetAll();

        return allOperators.Select(op => new OperatorAndTrainingDTO()
        {
          Operator = op,
          TrainingIDs = allTraining.Where(x => x.OperatorID == op.ID).Select(x => x.TrainingRequirementID).ToArray()
        }).ToList();
      }

  }
}
