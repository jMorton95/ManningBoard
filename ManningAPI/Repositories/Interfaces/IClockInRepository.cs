using ReactManningPoCAPI.Models;

namespace ReactManningPoCAPI.Repositories.Interfaces
{
    public interface IClockInRepository
    {
        Task<Operator?> CheckClockCardAsync(int clockCardNumber);
    }
}
