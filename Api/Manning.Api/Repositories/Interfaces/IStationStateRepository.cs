using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
  public interface IStationStateRepository : IBaseRepository<StationStateModel>
  {
    Task<StationStateModel?> GetStationStateByOperatorID(int operatorID);
    Task<List<StationStateModel?>> GetStationStateByStationID(int stationID);
  }
}