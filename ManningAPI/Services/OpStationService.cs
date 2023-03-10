using Microsoft.EntityFrameworkCore;
using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Repositories.Interfaces;
using ReactManningPoCAPI.Services.Interfaces;
using ReactManningPoCAPI.ViewModels;
using static ReactManningPoCAPI.ViewModels.OperatorGrouped;

namespace ReactManningPoCAPI.Services
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

        public List<OperatorAndTraining> GetAllOperatorsAndTraining()
        {
            //TODO: Refactor for efficiency/oversights
            List<Operator> allOperators = _operatorRepository.GetAllOperators();
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

        public List<OperatorGrouped> GetOperatorsGroupedByTraining(int opstationID)
        {
            List<int> stationTrainingIDs = _opStationRepository.GetOpStationTrainingIDs(opstationID);

            List<OperatorAndTraining> operators = GetAllOperatorsAndTraining();

            List<OperatorGrouped> groupedOperators = new();

            foreach (var _operator in operators)
            {
                if(stationTrainingIDs.All(s => _operator.TrainingIDs.Contains(s)))
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
