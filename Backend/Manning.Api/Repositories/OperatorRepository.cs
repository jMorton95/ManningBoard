using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
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
