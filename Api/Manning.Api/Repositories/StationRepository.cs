using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class StationRepository : BaseRepository<Station>, IStationRepository
    {
        public StationRepository(ManningDbContext dbContext) :base(dbContext)
        {
        }

        public async Task<List<Station>> GetStationsByZoneID(int zoneID)
        {
            var query = _dbContext.Station.Where(x => x.ZoneID == zoneID);
            return await query.ToListAsync();
        }

        public Task<Station> GetStationByID(int ID)
        {
            return Task.FromResult(_dbContext.Station.Include(o => o.TrainingRequirements!).First(x => x.ID == ID));
        }

        public async Task<List<int>> GetStationTrainingIDs(int stationID)
        {
            Station station = await GetStationByID(stationID);
            List<int> trainingIdS = new();

            if (station.TrainingRequirements == null) return trainingIdS;

            trainingIdS = station.TrainingRequirements.Select(x => x.ID).ToList();

            return trainingIdS;
        }

        public async Task<List<Station>> GetAllStations() => await _dbContext.Station.Include(o => o.TrainingRequirements!).ToListAsync();

        public async Task<Station> AddOperatorToStation(StationStateModel dto)
        {
          var findStationAssignment = await _dbContext.StationStateModel.FirstOrDefaultAsync(x => x.StationID == dto.StationID && x.IsTrainee == dto.IsTrainee);

          if (findStationAssignment == null)
          {
            _dbContext.StationStateModel.Add(dto);
          }
          else
          {
            findStationAssignment.OperatorID = dto.OperatorID;  
          }

          try
          {
            await _dbContext.SaveChangesAsync();
          }
          catch (Exception ex)
          {
            Console.WriteLine($"Failed to add Operator to Station: {ex.Message}");
          }

          return await GetById(dto.StationID);
        }
  }
}
