using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Services
{
    public class OpStationService : IOpStationService
    {
        private readonly IOpStationRepository _opStationRepository;
        private readonly IOperatorCompletedTrainingRepository _operatorCompletedTrainingRepository;
        public OpStationService
        (
          IOpStationRepository opStationRepository,
          IOperatorCompletedTrainingRepository operatorCompletedTrainingRepository
        )
        {
            _opStationRepository = opStationRepository;
            _operatorCompletedTrainingRepository = operatorCompletedTrainingRepository;
        }

        public async Task<Station?> AddOperatorToOpStation(OperatorAndStationIdDTO dto)
        {
          return await _opStationRepository.AddOperatorToOpStation(dto);
        }

        //TODO: Unit Test
        // public async Task<bool> CheckOperatorIsTrainedOnOpStation(OperatorAndStationIdDTO dto)
        // {
        //   Station station = await _opStationRepository.GetOpStationByID(dto.OpStationId);

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
        public async Task<bool> CheckOperatorIsTrainedOnOpStation(OperatorAndStationIdDTO dto)
        {
          List<int> opStationTrainingIds = await _opStationRepository.GetOpStationTrainingIDs(dto.OpStationId);

          if (opStationTrainingIds.Count < 1) return false;

          List<OperatorCompletedTraining> operatorTraining = await _operatorCompletedTrainingRepository.GetOperatorCompletedTraining(dto.OperatorId);
          return operatorTraining.All(x => opStationTrainingIds.Contains(x.TrainingRequirementID));
        }
  }
}
