using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;

namespace Manning.Api.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        private readonly IOperatorCompletedTrainingRepository _operatorCompletedTrainingRepository;
        private readonly IStationStateRepository _stationStateRepository;
        public StationService
        (
          IStationRepository stationRepository,
          IOperatorCompletedTrainingRepository operatorCompletedTrainingRepository,
          IStationStateRepository stationStateRepository
        )
        {
            _stationRepository = stationRepository;
            _operatorCompletedTrainingRepository = operatorCompletedTrainingRepository;
            _stationStateRepository = stationStateRepository;
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

        //TODO: Unit Test
        // public async Task<bool> CheckOperatorIsTrainedOnStation(StationStateModel dto)
        // {
        //   Station station = await _stationRepository.GetStationByID(dto.StationId);

        //   //Early return if there are no requirements.
        //   if (station.TrainingRequirements == null || station.TrainingRequirements.Count < 1)
        //   {
        //     return true;
        //   } 
            
        //   List<OperatorCompletedTraining> operatorTraining = await _operatorCompletedTrainingRepository.GetOperatorCompletedTraining(dto.OperatorId);
          
        //   //Operator must have all training required for Station
        //   return operatorTraining.All(x => station.TrainingRequirements.Any(o => o.ID == x.TrainingRequirementID));
        // }

        //TODO: This is the better implementation, make sure its all good
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
  }
}
