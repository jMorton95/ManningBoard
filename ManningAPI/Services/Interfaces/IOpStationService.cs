using ManningApi.Models;
using ManningApi.ViewModels;

namespace ManningApi.Services.Interfaces
{
    public interface IOpStationService
    {
       /* Task<List<Operator>> GetOperatorsByOpStation(int opstationID);*/
        Task<List<OperatorGrouped>> GetOperatorsGroupedByTraining(int opstationID);
        Task<List<OperatorAndTraining>> GetAllOperatorsAndTraining();
    }
}
