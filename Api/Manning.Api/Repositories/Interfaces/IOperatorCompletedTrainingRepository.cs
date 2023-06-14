using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IOperatorCompletedTrainingRepository : IBaseRepository<OperatorCompletedTraining>
    {
        Task<List<OperatorCompletedTraining>> GetAllCompletedTraining();
        Task<List<OperatorCompletedTraining>> GetOperatorCompletedTraining(int operatorID);
    }
}
