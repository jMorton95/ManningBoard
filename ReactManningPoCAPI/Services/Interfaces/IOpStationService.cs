using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.ViewModels;

namespace ReactManningPoCAPI.Services.Interfaces
{
    public interface IOpStationService
    {
       /* Task<List<Operator>> GetOperatorsByOpStation(int opstationID);*/
        List<OperatorGrouped> GetOperatorsGroupedByTraining(int opstationID);
        List<OperatorAndTraining> GetAllOperatorsAndTraining();
    }
}
