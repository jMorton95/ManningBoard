using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IWorkingDayHistoryRepository : IBaseRepository<WorkingDayHistory>
    {
        Task SaveCurrentShift(List<StationStateModel> currentShift, string shiftName);
    }
}
