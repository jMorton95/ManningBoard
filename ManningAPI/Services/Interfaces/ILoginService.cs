using ReactManningPoCAPI.Models;

namespace ReactManningPoCAPI.Services.Interfaces
{
    public interface ILoginService
    {
        string GenerateJwtToken(Operator op);
        bool ClockCardIsInvalid(int clockCardNumber);
        Task<Operator?> CheckClockCardAsync(int clockCardNumber);
    }
}
