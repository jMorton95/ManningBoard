using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class ClockInRepository : BaseRepository<ClockModel>, IClockInRepository
    {
        public ClockInRepository(ManningDbContext dbContext) :base(dbContext)
        {
        }
        public async Task<Operator?> CheckClockCardAsync(int clockCardNumber)
        {
            return await _dbContext.Operator.SingleOrDefaultAsync(o => o.ClockCardNumber == clockCardNumber);
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

            _dbContext.ClockModel.Add(clockIn);
            await _dbContext.SaveChangesAsync();
            return clockIn.ID;
        }

        public async Task ClockOperatorOut(int clockInId)
        {
            ClockModel clock = await GetById(clockInId);

            if (clock != null)
            {
                clock.ClockOutTime = DateTime.UtcNow;
                _dbContext.ClockModel.Update(clock);
                _dbContext.SaveChanges();
            };
        }

        public async Task<ClockModel> GetClockById(int clockInId) => await _dbContext.ClockModel.SingleAsync(c => c.ID == clockInId);

    }
}
