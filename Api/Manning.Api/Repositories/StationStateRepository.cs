using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
  public class StationStateRepository : BaseRepository<StationStateModel>, IStationStateRepository
  {
    public StationStateRepository(ManningDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<StationStateModel?> GetStationStateByOperatorID(int operatorID)
    {
      return await Task.FromResult(_dbContext.StationStateModel.FirstOrDefault(x => x.OperatorID == operatorID));
    }

    public async Task<StationStateModel?> GetStationStateByStationID(int stationID)
    {
      return await Task.FromResult(_dbContext.StationStateModel.FirstOrDefault(x => x.StationID == stationID));
    }
  }
}