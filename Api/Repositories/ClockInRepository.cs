using Microsoft.EntityFrameworkCore;
using ManningApi.Models;
using ManningApi.Repositories.Interfaces;

namespace ManningApi.Repositories
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
            ClockModel clockIn = new ClockModel()
            {
                ClockCardNumber = _operator.ClockCardNumber,
                OperatorName = _operator.OperatorName,
                ClockInTime = DateTime.Now
            };

            _context.ClockModel.Add(clockIn);
            await _context.SaveChangesAsync();
            return clockIn.ID;
        }

        public void ClockOperatorOut(int clockInId)
        {
            ClockModel clock = _context.ClockModel.FirstOrDefault(c => c.ID == clockInId);
            clock.ClockOutTime = DateTime.Now;
            _context.ClockModel.Update(clock);
             _context.SaveChanges();
        }

        public async Task<ClockModel> GetClockById(int clockInId) => await _context.ClockModel.SingleAsync(c => c.ID == clockInId);
        
    }
}
