using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Repositories
{
    public class StationRepository : BaseRepository<Station>, IStationRepository
    {
        public StationRepository(ManningDbContext dbContext) :base(dbContext)
        {
        }

        public async Task<List<Station>> GetStationsByZoneID(int zoneID)
        {
            var query = _dbContext.Station.Where(x => x.ZoneID == zoneID);
            return await query.ToListAsync();
        }

        public Task<Station> GetStationByID(int ID)
        {
            return Task.FromResult(_dbContext.Station.Include(o => o.TrainingRequirements!).First(x => x.ID == ID));
        }

        public async Task<List<int>> GetStationTrainingIDs(int stationID)
        {
            Station station = await GetStationByID(stationID);
            List<int> trainingIdS = new();

            if (station.TrainingRequirements == null) return trainingIdS;

            trainingIdS = station.TrainingRequirements.Select(x => x.ID).ToList();

            return trainingIdS;
        }

        public async Task<List<Station>> GetAllStations() => await _dbContext.Station.Include(o => o.TrainingRequirements!).ToListAsync();

        public Task<Station> AddOperatorToStation(OperatorAndStationIdDTO dto)
        {
          throw new NotImplementedException();
        }

        public void RemoveOperatorFromStation(OperatorAndStationIdDTO dto)
        {
          throw new NotImplementedException();
        }
  }
}
