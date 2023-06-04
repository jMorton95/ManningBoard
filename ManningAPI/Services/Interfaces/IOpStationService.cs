using ManningApi.Models;
using ManningApi.ViewModels;

namespace ManningApi.Services.Interfaces
{
    public interface IOpStationService
    {
       /* Task<List<Operator>> GetOperatorsByOpStation(int opstationID);*/
        List<OperatorGrouped> GetOperatorsGroupedByTraining(int opstationID);
        List<OperatorAndTraining> GetAllOperatorsAndTraining();
    }
}
