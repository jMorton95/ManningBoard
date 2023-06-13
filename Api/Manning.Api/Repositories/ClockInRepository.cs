using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class ClockInRepository : IClockInRepository
    {
        private readonly ManningDbContext _context;
        public ClockInRepository(ManningDbContext context)
        {
            _context = context;
        }
        public async Task<Operator?> CheckClockCardAsync(int clockCardNumber)
        {
            return await _context.Operator.SingleOrDefaultAsync(o => o.ClockCardNumber == clockCardNumber);
        }

        public async Task<int> ClockOperatorIn(Operator _operator)
        {
            ClockModel clockIn = new()
            {
                ClockCardNumber = _operator.ClockCardNumber,
                OperatorName = _operator.OperatorName,
                ClockInTime = DateTime.UtcNow,
                ClockOutTime = DateTime.UtcNow.AddHours(6)
            };

            _context.ClockModel.Add(clockIn);
            await _context.SaveChangesAsync();
            return clockIn.ID;
        }

        public void ClockOperatorOut(int clockInId)
        {
            ClockModel clock = _context.ClockModel.First(c => c.ID == clockInId);

            if (clock != null)
            {
                clock.ClockOutTime = DateTime.UtcNow;
                _context.ClockModel.Update(clock);
                _context.SaveChanges();
            };
        }

        public async Task<ClockModel> GetClockById(int clockInId) => await _context.ClockModel.SingleAsync(c => c.ID == clockInId);

    }
}
