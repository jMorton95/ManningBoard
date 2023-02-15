using Microsoft.EntityFrameworkCore;
using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Repositories.Interfaces;
using ReactManningPoCAPI.ViewModels;

namespace ReactManningPoCAPI.Repositories
{
    public class OperatorCompletedTrainingRepository : IOperatorCompletedTrainingRepository
    {
        private readonly ManningDbContext _DbContext;
        public OperatorCompletedTrainingRepository(ManningDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public List<OperatorCompletedTraining> GetAllCompletedTraining()
        {
            return _DbContext.OperatorCompletedTraining.ToList();
        }

        public List<OperatorCompletedTraining> GetOperatorCompletedTraining(int operatorID)
        {
            return _DbContext.OperatorCompletedTraining.Where(x => x.OperatorID == operatorID).ToList();
        }
    }
}
