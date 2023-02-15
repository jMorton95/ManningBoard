using Microsoft.EntityFrameworkCore;
using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Repositories.Interfaces;

namespace ReactManningPoCAPI.Repositories
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

        public List<Operator> GetAllOperators()
        {
            return _DbContext.Operator.ToList();
        }
    }
}
