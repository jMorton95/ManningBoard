using Microsoft.EntityFrameworkCore;
using ManningApi.Models;

namespace ManningApi.Repositories
{
    public class ManningDbContext : DbContext
    {
        public ManningDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Operator>? Operator { get; set; }
        public DbSet<Zone>? Zone { get; set; }
        public DbSet<OpStation>? OpStation { get; set; }
        public DbSet<TrainingRequirement>? TrainingRequirement { get; set; }
        public DbSet<TrainingRequirementType>? TrainingRequirementsType { get; set; }
        public DbSet<OperatorCompletedTraining>? OperatorCompletedTraining {  get; set; }
        public DbSet<ShiftType>? ShiftType { get; set; }
        public DbSet<WorkingDayHistory>? WorkdayHistory { get; set; }
        public DbSet<ClockModel>? ClockModel { get; set; }
    }
}
