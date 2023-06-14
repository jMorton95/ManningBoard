using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class OperatorRepository : BaseRepository<Operator>, IOperatorRepository
    {
         public OperatorRepository(ManningDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Operator>> GetAllOperatorsAsync()
        {
            return await _dbContext.Operator.ToListAsync();
        }

        public Task<List<Operator>> GetAllOperators()
        {
            return _dbContext.Operator.ToListAsync();
        }
  }
}
