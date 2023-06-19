using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Manning.Api.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        private readonly IOperatorCompletedTrainingRepository _operatorCompletedTrainingRepository;
        private readonly IStationStateRepository _stationStateRepository;
        private readonly IOperatorRepository _operatorRepository;
        public StationService
        (
          IStationRepository stationRepository,
          IOperatorCompletedTrainingRepository operatorCompletedTrainingRepository,
          IStationStateRepository stationStateRepository,
          IOperatorRepository operatorRepository
        )
        {
            _stationRepository = stationRepository;
            _operatorCompletedTrainingRepository = operatorCompletedTrainingRepository;
            _stationStateRepository = stationStateRepository;
            _operatorRepository = operatorRepository;
        }

        public async Task AddOperatorToStation(StationStateModel dto)
        {
          await RemoveAssignedOperatorFromOtherStation(dto);
          await _stationRepository.AddOperatorToStation(dto);
        }

        public async Task RemoveAssignedOperatorFromOtherStation(StationStateModel dto)
        {
          StationStateModel? assignedOperator = await _stationStateRepository.GetStationStateByOperatorID(dto.OperatorID);

          if (assignedOperator != null && assignedOperator.StationID != dto.StationID)
          {
            await _stationStateRepository.Delete(assignedOperator);
          }
        }

        public async Task<bool> CheckOperatorIsTrainedOnStation(StationStateModel dto)
        {
          List<int> stationTrainingIds = await _stationRepository.GetStationTrainingIDs(dto.StationID);

          if (stationTrainingIds.Count < 1) return false;

          List<OperatorCompletedTraining> operatorTraining = await _operatorCompletedTrainingRepository.GetOperatorCompletedTraining(dto.OperatorID);
          return operatorTraining.All(x => stationTrainingIds.Contains(x.TrainingRequirementID));
        }

        public async Task RemoveOperatorFromStation(StationStateModel dto)
        {
          await _stationStateRepository.Delete(dto);
          await _stationRepository.GetById(dto.StationID);
        }

        public async Task<StationAssignableOperatorsDTO> GetAssignableOperatorsGrouped(int stationID)
        {
          Station station = await _stationRepository.GetStationByID(stationID);
          List<OperatorAndTrainingDTO> opsAndTraining = await GroupOperatorsWithTraining();

          if (station.TrainingRequirements == null || station.TrainingRequirements.Count < 1)
          {
            return new StationAssignableOperatorsDTO();
          }

          List<Operator?> validOperators = opsAndTraining
          .Where(op => 
            station.TrainingRequirements.All(req => op.TrainingIDs.Contains(req.ID))
          )
          .Select(x => x.Operator)
          .ToList();

          //validOperators = validOperators ?? new List<Operator?>();

          List<Operator?> trainingOperators = opsAndTraining
            .Where(op => validOperators.Exists(x => x.ID != op.Operator.ID) &&
              station.TrainingRequirements.Any(req => op.TrainingIDs.Contains(req.ID))
            )
            .Select(x => x.Operator)
            .ToList();

            //trainingOperators = trainingOperators ?? new List<Operator?>();

            return new StationAssignableOperatorsDTO()
            {
                ValidOperators = validOperators,
                TrainingOperators = trainingOperators
            };
        }

        public async Task<List<OperatorAndTrainingDTO>> GroupOperatorsWithTraining()
        {
          var allOperators = await _operatorRepository.GetAll();
          var allTraining = await _operatorCompletedTrainingRepository.GetAll();
          var operatorsAndTraining = allOperators.Select(op => new OperatorAndTrainingDTO()
          {
            Operator = op,
            TrainingIDs = allTraining.Where(x => x.OperatorID == op.ID).Select(x => x.TrainingRequirementID).ToArray()
          }).ToList();

            return operatorsAndTraining;
        }
  }
}
