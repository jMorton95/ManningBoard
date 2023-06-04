using Microsoft.EntityFrameworkCore;
using ManningApi.Models;
using ManningApi.Repositories.Interfaces;

namespace ManningApi.Repositories
{
    public class ZonesRepository  : BaseRepository<Zone>, IZonesRepository
    {
        public ZonesRepository(ManningDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Zone>> GetAllZonesAndOpStations()
        {
            return await _dbContext.Zone.Include(x => x.OpStations!).ThenInclude(x => x.TrainingRequirements!).ThenInclude(x => x.TrainingRequirementType).ToListAsync();
        }
    }
}
