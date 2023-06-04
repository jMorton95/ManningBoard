using ManningApi.Models;

namespace ManningApi.Repositories.Interfaces
{
    public interface IOperatorRepository
    {
        Task<List<Operator>> GetAllOperatorsAsync();
        Task<List<Operator>> GetAllOperators();
    }
}
