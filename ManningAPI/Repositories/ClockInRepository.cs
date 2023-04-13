using Microsoft.EntityFrameworkCore;
using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Repositories.Interfaces;

namespace ReactManningPoCAPI.Repositories
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
