using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        private readonly IOperatorCompletedTrainingRepository _operatorCompletedTrainingRepository;
        public StationService
        (
          IStationRepository stationRepository,
          IOperatorCompletedTrainingRepository operatorCompletedTrainingRepository
        )
        {
            _stationRepository = stationRepository;
            _operatorCompletedTrainingRepository = operatorCompletedTrainingRepository;
        }

        public async Task<Station?> AddOperatorToStation(OperatorAndStationIdDTO dto)
        {
          return await _stationRepository.AddOperatorToStation(dto);
        }

        //TODO: Unit Test
        // public async Task<bool> CheckOperatorIsTrainedOnStation(OperatorAndStationIdDTO dto)
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
        public async Task<bool> CheckOperatorIsTrainedOnStation(OperatorAndStationIdDTO dto)
        {
          List<int> stationTrainingIds = await _stationRepository.GetStationTrainingIDs(dto.StationId);

          if (stationTrainingIds.Count < 1) return false;

          List<OperatorCompletedTraining> operatorTraining = await _operatorCompletedTrainingRepository.GetOperatorCompletedTraining(dto.OperatorId);
          return operatorTraining.All(x => stationTrainingIds.Contains(x.TrainingRequirementID));
        }
  }
}
