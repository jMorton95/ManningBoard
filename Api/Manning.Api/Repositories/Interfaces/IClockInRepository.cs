using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IClockInRepository : IBaseRepository<ClockModel>
    {
        Task<Operator?> CheckClockCardAsync(int clockCardNumber);
        Task<int> ClockOperatorIn(Operator _operator);
        Task<ClockModel> GetClockById(int clockInId);
        Task ClockOperatorOut(int clockInId);
    }
}
