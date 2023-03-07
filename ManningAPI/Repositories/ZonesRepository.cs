using Microsoft.EntityFrameworkCore;
using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Repositories.Interfaces;

namespace ReactManningPoCAPI.Repositories
{
    public class ZonesRepository : IZonesRepository
    {
        private readonly ManningDbContext _dbContext;
        public ZonesRepository(ManningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Zone>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Zone>> GetAllZones()
        {
            return await _dbContext.Zone.ToListAsync();
        }

        public async Task<List<Zone>> GetAllZonesAndOpStations()
        {
            return await _dbContext.Zone.Include(x => x.OpStations!).ThenInclude(x => x.TrainingRequirements!).ThenInclude(x => x.TrainingRequirementType).ToListAsync();
        }

        public Task<Zone> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
