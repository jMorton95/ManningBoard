using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IOperatorRepository
    {
        Task<List<Operator>> GetAllOperatorsAsync();
        Task<List<Operator>> GetAllOperators();
    }
}
