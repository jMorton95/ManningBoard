﻿using ManningApi.Models;

namespace ManningApi.Services.Interfaces
{
    public interface ILoginService
    {
        string GenerateJwtToken(Operator op);
        bool ClockCardIsInvalid(int clockCardNumber);
        Task<Operator?> CheckClockCardAsync(int clockCardNumber);
    }
}
