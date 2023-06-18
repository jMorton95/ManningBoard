using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Services.Interfaces
{
    public interface IStationService
    {
        Task AddOperatorToStation(StationStateModel dto);
        Task RemoveOperatorFromStation(StationStateModel dto);
        Task<bool> CheckOperatorIsTrainedOnStation(StationStateModel dto);
        Task RemoveAssignedOperatorFromOtherStation(StationStateModel dto);
        
    }
}
