using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class ZonesRepository : BaseRepository<Zone>, IZonesRepository
    {
        public ZonesRepository(ManningDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Zone>> GetAllZonesAndStations()
        {
            return await _dbContext.Zone.Include(x => x.Stations!).ThenInclude(x => x.TrainingRequirements!).ToListAsync();
        }
    }
}
