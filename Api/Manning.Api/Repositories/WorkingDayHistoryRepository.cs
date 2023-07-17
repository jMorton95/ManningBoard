using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class WorkingDayHistoryRepository : BaseRepository<WorkingDayHistory>, IWorkingDayHistoryRepository
    {
        public WorkingDayHistoryRepository(ManningDbContext dbContext) :base(dbContext) { }
        public async Task SaveCurrentShift(List<StationStateModel> currentShift, string shiftName)
        {
            IEnumerable<WorkingDayHistory> saveShiftState = currentShift.Select(x => new WorkingDayHistory() { ShiftDate = DateTime.UtcNow, ShiftName = shiftName, StationState = x });

            await _dbContext.AddRangeAsync(saveShiftState);
            await _dbContext.SaveChangesAsync();
        }
    }
}
