using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Repositories
{
    public class OpStationRepository : BaseRepository<Station>, IOpStationRepository
    {
        public OpStationRepository(ManningDbContext dbContext) :base(dbContext)
        {
        }

        public async Task<List<Station>> GetOpStationsByZoneID(int zoneID)
        {
            var query = _dbContext.Station.Where(x => x.ZoneID == zoneID);
            return await query.ToListAsync();
        }

        public Task<Station> GetOpStationByID(int ID)
        {
            return Task.FromResult(_dbContext.Station.Include(o => o.TrainingRequirements!).First(x => x.ID == ID));
        }

        public async Task<List<int>> GetOpStationTrainingIDs(int opstationID)
        {
            Station station = await GetOpStationByID(opstationID);
            List<int> trainingIdS = new();

            if (station.TrainingRequirements == null) return trainingIdS;

            trainingIdS = station.TrainingRequirements.Select(x => x.ID).ToList();

            return trainingIdS;
        }

        public async Task<List<Station>> GetAllOpStations() => await _dbContext.Station.Include(o => o.TrainingRequirements!).ToListAsync();

        public Task<Station> AddOperatorToOpStation(OperatorAndStationIdDTO dto)
        {
          throw new NotImplementedException();
        }

        public void RemoveOperatorFromOpStation(OperatorAndStationIdDTO dto)
        {
          throw new NotImplementedException();
        }
  }
}
