using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
  public interface IStationStateRepository : IBaseRepository<StationStateModel>
  {
    Task<StationStateModel?> GetStationStateByOperatorID(int operatorID);
    Task<StationStateModel?> GetStationStateByStationID(int stationID);
  }
}