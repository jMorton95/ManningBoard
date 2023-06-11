﻿using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class OpStationRepository : IOpStationRepository
    {
        private readonly ManningDbContext _DbContext;
        public OpStationRepository(ManningDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<List<OpStation>> GetAllOpStationsAsync()
        {
            return await _DbContext.OpStation.Include(o => o.TrainingRequirements!).ThenInclude(t => t.TrainingRequirementType).ToListAsync();
        }

        public async Task<List<OpStation>> GetOpStationsByZoneID(int zoneID)
        {
            var query = _DbContext.OpStation.Where(x => x.ZoneID == zoneID);
            return await query.ToListAsync();
        }

        public Task<OpStation> GetOpStationByID(int ID)
        {
            return Task.FromResult(_DbContext.OpStation.Include(o => o.TrainingRequirements!).ThenInclude(t => t.TrainingRequirementType).First(x => x.ID == ID));
        }

        public async Task<List<int>> GetOpStationTrainingIDs(int opstationID)
        {
            OpStation station = await GetOpStationByID(opstationID);
            List<int> trainingIDS = new List<int>();

            if (station.TrainingRequirements == null) return trainingIDS;

            foreach (var req in station.TrainingRequirements)
            {
                if (req.TrainingRequirementTypeId == 1)
                {
                    trainingIDS.Add(req.ID);
                }
            }
            return trainingIDS;
        }

        public List<OpStation> GetAllOpStations() => _DbContext.OpStation.Include(o => o.TrainingRequirements!).ThenInclude(t => t.TrainingRequirementType).ToList();
    }
}
