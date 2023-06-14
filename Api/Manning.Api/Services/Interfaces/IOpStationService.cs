using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Services.Interfaces
{
    public interface IOpStationService
    {
        Task<OpStation?> AddOperatorToOpStation(OperatorAndStationIdDTO dto);
        Task<bool> CheckOperatorIsTrainedOnOpStation(OperatorAndStationIdDTO dto);
    }
}
