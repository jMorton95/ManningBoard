using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;

namespace Manning.Api.Repositories
{
    public class ManningDbContext : DbContext
    {
        public ManningDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Operator> Operator => Set<Operator>();
        public DbSet<Zone> Zone => Set<Zone>();
        public DbSet<Station> Station => Set<Station>();
        public DbSet<TrainingRequirement> TrainingRequirement => Set<TrainingRequirement>();
        public DbSet<OperatorCompletedTraining> OperatorCompletedTraining => Set<OperatorCompletedTraining>();
        public DbSet<ShiftType> ShiftType => Set<ShiftType>();
        public DbSet<WorkingDayHistory> WorkdayHistory => Set<WorkingDayHistory>();
        public DbSet<ClockModel> ClockModel => Set<ClockModel>();
        public DbSet<AssignedOperatorsModel> AssignedOperatorsModels => Set<AssignedOperatorsModel>();
    }
}
