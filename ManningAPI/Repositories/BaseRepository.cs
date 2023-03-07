using Microsoft.EntityFrameworkCore;
using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Repositories.Interfaces;

namespace ReactManningPoCAPI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly ManningDbContext _dbContext;
        public BaseRepository(ManningDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<T>> GetAll()
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
