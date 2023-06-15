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

        public async Task<Station> AddOperatorToStation(StationStateModel dto)
        {
          return await _stationRepository.AddOperatorToStation(dto);
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

        public Task<Station> RemoveOperatorFromStation(StationStateModel dto)
        {
          _stationStateRepository.Delete(dto);
          return _stationRepository.GetById(dto.StationID);
        }
  }
}
