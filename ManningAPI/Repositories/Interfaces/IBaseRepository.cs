using ManningApi.Models;

namespace ManningApi.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
