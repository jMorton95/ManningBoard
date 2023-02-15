using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.ViewModels;

namespace ReactManningPoCAPI.Repositories.Interfaces
{
    public interface IOperatorCompletedTrainingRepository
    {
        List<OperatorCompletedTraining> GetAllCompletedTraining();
        List<OperatorCompletedTraining> GetOperatorCompletedTraining(int operatorID);
    }
}
