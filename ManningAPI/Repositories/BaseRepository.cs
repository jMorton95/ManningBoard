using Microsoft.EntityFrameworkCore;
using ManningApi.Models;
using ManningApi.Repositories.Interfaces;

namespace ManningApi.Repositories
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
            return Task.FromResult(_dbContext.Set<T>().Single(x => x.ID == id));
        }
    }
}
