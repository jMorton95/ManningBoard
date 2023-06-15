using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Services.Interfaces
{
    public interface IStationService
    {
        Task<Station> AddOperatorToStation(StationStateModel dto);
        Task<Station> RemoveOperatorFromStation(StationStateModel dto);
        Task<bool> CheckOperatorIsTrainedOnStation(StationStateModel dto);
        
    }
}
