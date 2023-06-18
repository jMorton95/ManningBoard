using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IOperatorCompletedTrainingRepository : IBaseRepository<OperatorCompletedTraining>
    {
        Task<List<OperatorCompletedTraining>> GetOperatorCompletedTraining(int operatorID);
    }
}
