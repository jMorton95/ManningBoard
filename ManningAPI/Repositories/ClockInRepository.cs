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
    }
}
