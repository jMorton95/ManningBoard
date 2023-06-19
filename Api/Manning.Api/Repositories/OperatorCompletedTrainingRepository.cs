using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class OperatorCompletedTrainingRepository : BaseRepository<OperatorCompletedTraining>, IOperatorCompletedTrainingRepository
    {
        
        public OperatorCompletedTrainingRepository(ManningDbContext dbContext) :base(dbContext)
        {
        }

        public async Task<List<OperatorCompletedTraining>> GetOperatorCompletedTraining(int operatorID)
        {
            return await _dbContext.OperatorCompletedTraining.Where(x => x.OperatorID == operatorID).ToListAsync();
        }
    }
}
