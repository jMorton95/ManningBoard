using Manning.Api.Models;
using Manning.Api.ViewModels;

namespace Manning.Api.Services.Interfaces
{
    public interface IOpStationService
    {
       /* Task<List<Operator>> GetOperatorsByOpStation(int opstationID);*/
        Task<List<OperatorGrouped>> GetOperatorsGroupedByTraining(int opstationID);
        Task<List<OperatorAndTraining>> GetAllOperatorsAndTraining();
    }
}
