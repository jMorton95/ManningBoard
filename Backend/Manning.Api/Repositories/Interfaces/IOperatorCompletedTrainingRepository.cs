using ManningApi.Models;
using ManningApi.ViewModels;

namespace ManningApi.Repositories.Interfaces
{
    public interface IOperatorCompletedTrainingRepository
    {
        List<OperatorCompletedTraining> GetAllCompletedTraining();
        List<OperatorCompletedTraining> GetOperatorCompletedTraining(int operatorID);
    }
}
