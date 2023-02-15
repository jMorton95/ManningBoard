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
        public async Task<TrainingRequirement> GetTrainingRequirementByIDAsync(int ID)
        {
            return await Task.FromResult(_context.TrainingRequirement.Include(x => x.TrainingRequirementType).First(x => x.ID == ID));
        }
        public async Task<TrainingRequirement> AddNewPrerequisite(string requirementDescription, int opstationID)
        {
            TrainingRequirement post = new TrainingRequirement { RequirementDescription = requirementDescription, OpStationID = opstationID, TrainingRequirementTypeId = 1 };
            _context.TrainingRequirement.Add(post);
            _context.SaveChanges();
            return await GetTrainingRequirementByIDAsync(post.ID);
        }
    }
}
