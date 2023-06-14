using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class TrainingRequirementRepository : BaseRepository<TrainingRequirement>, ITrainingRequirementRepository
    {
        public TrainingRequirementRepository(ManningDbContext dbContext) : base(dbContext)
        {
           
        }
        public async Task<TrainingRequirement?> GetTrainingRequirementByIDAsync(int ID)
        {
            return await _dbContext.TrainingRequirement.FirstOrDefaultAsync(x => x.ID == ID);
        }
        public async Task<TrainingRequirement> AddNewPrerequisite(TrainingRequirement newRequirement)
        {
            _dbContext.TrainingRequirement.Add(newRequirement);
            await _dbContext.SaveChangesAsync();
            return newRequirement;
        }

        public async Task<List<TrainingRequirement>> GetTrainingRequirementsByStationId(int ID)
        {
          return await _dbContext.TrainingRequirement.Where(x => x.StationID == ID).ToListAsync();
        }
  }
}
