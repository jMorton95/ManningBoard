using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
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
            return Task.FromResult(_dbContext.Set<T>().First(x => x.ID == id));
        }

        public async Task Delete(T item)
        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x == item);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
  }

    
}
