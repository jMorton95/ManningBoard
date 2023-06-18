using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IOperatorRepository : IBaseRepository<Operator>
    {
      Task<List<OperatorAndTrainingDTO>> GroupAllOperatorsWithTraining();
      Task<OperatorAndTrainingDTO> GroupOperatorWithTraining(int operatorID);
    }
}
