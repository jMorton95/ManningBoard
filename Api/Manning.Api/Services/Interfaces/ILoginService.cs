﻿using Manning.Api.Models;

namespace Manning.Api.Services.Interfaces
{
    public interface ILoginService
    {
        string GenerateJwtToken(Operator op);
        bool ClockCardIsInvalid(int clockCardNumber);
        Task<Operator?> CheckClockCardAsync(int clockCardNumber);
        Task<int> ClockOperatorIn(Operator op);
        Task<ClockModel?> TryGetClockInFromJWT(string jwtToken);
        Task ClockOperatorOut(int sessionID);
    }
}
