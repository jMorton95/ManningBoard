using Microsoft.EntityFrameworkCore;
using ManningApi.Models;
using ManningApi.Repositories.Interfaces;

namespace ManningApi.Repositories
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly ManningDbContext _DbContext;
        public OperatorRepository(ManningDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<List<Operator>> GetAllOperatorsAsync()
        {
            return await _DbContext.Operator.ToListAsync();
        }

        public Task<List<Operator>> GetAllOperators()
        {
            return _DbContext.Operator.ToListAsync();
        }
    }
}
