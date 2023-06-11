using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
