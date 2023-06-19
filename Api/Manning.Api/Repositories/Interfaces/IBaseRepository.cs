using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T> GetById(int id);
        Task<List<T>> GetManyById(int[] ids);
        Task<List<T>> GetManyByExcludedID(int[] ids);
        Task<List<T>> GetAll();
        Task<List<T>> GetAllNoTracking();
        Task Delete(T item);
    }
}
