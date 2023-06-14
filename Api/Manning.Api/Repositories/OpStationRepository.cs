using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Repositories
{
    public class OpStationRepository : BaseRepository<OpStation>, IOpStationRepository
    {
        public OpStationRepository(ManningDbContext dbContext) :base(dbContext)
        {
        }

        public async Task<List<OpStation>> GetOpStationsByZoneID(int zoneID)
        {
            var query = _dbContext.OpStation.Where(x => x.ZoneID == zoneID);
            return await query.ToListAsync();
        }

        public Task<OpStation> GetOpStationByID(int ID)
        {
            return Task.FromResult(_dbContext.OpStation.Include(o => o.TrainingRequirements!).First(x => x.ID == ID));
        }

        public async Task<List<int>> GetOpStationTrainingIDs(int opstationID)
        {
            OpStation station = await GetOpStationByID(opstationID);
            List<int> trainingIdS = new();

            if (station.TrainingRequirements == null) return trainingIdS;

            trainingIdS = station.TrainingRequirements.Select(x => x.ID).ToList();

            return trainingIdS;
        }

        public async Task<List<OpStation>> GetAllOpStations() => await _dbContext.OpStation.Include(o => o.TrainingRequirements!).ToListAsync();

        public Task<OpStation> AddOperatorToOpStation(OperatorAndStationIdDTO dto)
        {
          throw new NotImplementedException();
        }

        public void RemoveOperatorFromOpStation(OperatorAndStationIdDTO dto)
        {
          throw new NotImplementedException();
        }
  }
}
