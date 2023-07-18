using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class WorkingDayHistoryRepository : BaseRepository<WorkingDayHistory>, IWorkingDayHistoryRepository
    {
        public WorkingDayHistoryRepository(ManningDbContext dbContext) :base(dbContext) { }
        public async Task SaveCurrentShift(List<StationStateModel> currentShift, string shiftName)
        {
            IEnumerable<WorkingDayHistory> saveShiftState = currentShift.Select(x => new WorkingDayHistory()
            {
                ShiftDate = DateTime.UtcNow, ShiftName = shiftName, StationID = x.StationID, OperatorID = x.OperatorID, IsTrainee = x.IsTrainee
            });

            await _dbContext.AddRangeAsync(saveShiftState);
            await _dbContext.SaveChangesAsync();
        }
    }
}
