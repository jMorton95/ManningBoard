using ManningApi.Models;

namespace ManningApi.Repositories.Interfaces
{
    public interface IClockInRepository
    {
        Task<Operator?> CheckClockCardAsync(int clockCardNumber);
    }
}
