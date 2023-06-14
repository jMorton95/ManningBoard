using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IOperatorRepository : IBaseRepository<Operator>
    {
        Task<List<Operator>> GetAllOperators();
    }
}
