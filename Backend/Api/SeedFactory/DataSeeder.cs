using System.Reflection.Metadata.Ecma335;
using ManningApi.Models;
using ManningApi.Repositories;

namespace ManningAPI.SeedFactory;

public class DataSeeder : IDataSeeder
{
    private readonly ManningDbContext _dbContext;

    public DataSeeder(ManningDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void SeedLine()
    {
        List<Zone> ZonesData = new();

        foreach (var data in ZoneOpStationsSeedData){
            List<OpStation> _opStations = data.Value.Select(x => new OpStation() { StationName = x }).ToList();
            Zone _zone = new() { ZoneName = data.Key, OpStations = _opStations };
            ZonesData.Add(_zone);
        }

        _dbContext.Add(ZonesData);
        _dbContext.SaveChanges();
    }

    public void SeedOperators()
    {
        throw new NotImplementedException();
    }

    public void SeedTraining()
    {
        throw new NotImplementedException();
    }

    #region Data
    
    private Dictionary<string, string[]> ZoneOpStationsSeedData = new()
    {
        {
            "Manufacturing",
            new string[]
            { 
                "Engine",
                "Transmission",
                "Brakes",
                "Fuel Pump",
                "Gearbox",
                "Exhaust"
            }
        },
        {
            "Fabrication",
            new string[]
            {
                "Chassis",
                "Interior",
                "Airbags",
                "Entertainment"
            }
        },
         {
            "Assembly",
            new string[]
            {
                "Quality Pass",
                "External",
                "Internal",
                "Paint & Trimming"
            }
        }
    };
    #endregion
}   