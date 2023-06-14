using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Services.Interfaces
{
    public interface IStationService
    {
        Task<Station?> AddOperatorToStation(OperatorAndStationIdDTO dto);
        Task<bool> CheckOperatorIsTrainedOnStation(OperatorAndStationIdDTO dto);
    }
}
