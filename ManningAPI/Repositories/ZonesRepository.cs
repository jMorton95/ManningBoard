using Microsoft.EntityFrameworkCore;
using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Repositories.Interfaces;

namespace ReactManningPoCAPI.Repositories
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
