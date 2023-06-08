﻿using Microsoft.EntityFrameworkCore;
using ManningApi.Models;

namespace ManningApi.Repositories
{
    public class ManningDbContext : DbContext
    {
        public ManningDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Operator> Operator => Set<Operator>();
        public DbSet<Zone> Zone => Set<Zone>();
        public DbSet<OpStation> OpStation =>  Set<OpStation>();
        public DbSet<TrainingRequirement> TrainingRequirement =>  Set<TrainingRequirement>();
        public DbSet<TrainingRequirementType> TrainingRequirementsType => Set<TrainingRequirementType>();
        public DbSet<OperatorCompletedTraining> OperatorCompletedTraining => Set<OperatorCompletedTraining>();
        public DbSet<ShiftType> ShiftType => Set<ShiftType>();
        public DbSet<WorkingDayHistory> WorkdayHistory => Set<WorkingDayHistory>();
        public DbSet<ClockModel> ClockModel => Set<ClockModel>();
    }
}
