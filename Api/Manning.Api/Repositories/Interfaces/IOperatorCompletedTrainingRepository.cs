using Manning.Api.Models;
using Manning.Api.ViewModels;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IOperatorCompletedTrainingRepository
    {
        List<OperatorCompletedTraining> GetAllCompletedTraining();
        List<OperatorCompletedTraining> GetOperatorCompletedTraining(int operatorID);
    }
}
