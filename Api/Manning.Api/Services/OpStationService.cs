using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;
using Manning.Api.ViewModels;
using static Manning.Api.ViewModels.OperatorGrouped;

namespace Manning.Api.Services
{
    public class OpStationService : IOpStationService
    {
        private readonly IOpStationRepository _opStationRepository;
        private readonly IOperatorRepository _operatorRepository;
        private readonly IOperatorCompletedTrainingRepository _operatorCompletedTrainingRepository;
        public OpStationService(IOpStationRepository opStationRepository, IOperatorRepository operatorRepository, IOperatorCompletedTrainingRepository operatorCompletedTrainingRepository)
        {
            _opStationRepository = opStationRepository;
            _operatorRepository = operatorRepository;
            _operatorCompletedTrainingRepository = operatorCompletedTrainingRepository;
        }

        public async Task<List<OperatorAndTraining>> GetAllOperatorsAndTraining()
        {
            //TODO: Refactor for efficiency/oversights
            List<Operator> allOperators = await _operatorRepository.GetAllOperators();
            List<OperatorAndTraining> opsByTraining = new();

            //Conscious of calling a Repo in a foreach loop
            foreach (Operator op in allOperators)
            {
                List<int> opTrainingIDs = new();
                var operatorCompletedTraining = _operatorCompletedTrainingRepository.GetOperatorCompletedTraining(op.ID);
                foreach (var requirement in operatorCompletedTraining)
                {
                    opTrainingIDs.Add(requirement.TrainingRequirementID);
                }
                opsByTraining.Add(new OperatorAndTraining(op, opTrainingIDs));
            }

            return opsByTraining;
        }

        public async Task<List<OperatorGrouped>> GetOperatorsGroupedByTraining(int opstationID)
        {
            List<int> stationTrainingIDs = await _opStationRepository.GetOpStationTrainingIDs(opstationID);

            List<OperatorAndTraining> operators = await GetAllOperatorsAndTraining();

            List<OperatorGrouped> groupedOperators = new();

            foreach (var _operator in operators)
            {
                if (stationTrainingIDs.All(s => _operator.TrainingIDs.Contains(s)))
                {
                    groupedOperators.Add(new OperatorGrouped(_operator.Operator, StatusColor.Green));
                }
                else if (stationTrainingIDs.Any(s => _operator.TrainingIDs.Contains(s)))
                {
                    groupedOperators.Add(new OperatorGrouped(_operator.Operator, StatusColor.Yellow));
                }
                else
                {
                    groupedOperators.Add(new OperatorGrouped(_operator.Operator, StatusColor.Red));
                }
            }

            return groupedOperators;
        }
    }
}
