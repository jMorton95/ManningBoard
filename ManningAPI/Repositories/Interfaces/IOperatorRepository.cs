using ReactManningPoCAPI.Models;

namespace ReactManningPoCAPI.Repositories.Interfaces
{
    public interface IOperatorRepository
    {
        Task<List<Operator>> GetAllOperatorsAsync();
        List<Operator> GetAllOperators();
    }
}
