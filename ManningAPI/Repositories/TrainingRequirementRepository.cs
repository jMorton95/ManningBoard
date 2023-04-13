using Microsoft.EntityFrameworkCore;
using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Repositories.Interfaces;

namespace ReactManningPoCAPI.Repositories
{
    public class TrainingRequirementRepository : ITrainingRequirementRepository
    {
        private readonly ManningDbContext _context;
        public TrainingRequirementRepository(ManningDbContext context)
        {
            _context = context;
        }
        public async Task<TrainingRequirement?> GetTrainingRequirementByIDAsync(int ID)
        {
            return await _context.TrainingRequirement.Include(x => x.TrainingRequirementType).FirstOrDefaultAsync(x => x.ID == ID);
        }
        public async Task<TrainingRequirement> AddNewPrerequisite(TrainingRequirement newRequirement)
        {
            _context.TrainingRequirement.Add(newRequirement);
            await _context.SaveChangesAsync();
            return newRequirement;
        }
    }
}
