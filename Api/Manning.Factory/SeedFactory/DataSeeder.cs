namespace Manning.Factory.SeedFactory;
using Manning.Api.Models;
using Manning.Api.Repositories;

public class DataSeeder : IDataSeeder
{
    private readonly ManningDbContext _dbContext;

    public DataSeeder(ManningDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void RunDataSeed()
    {
      if (_dbContext.Zone.ToList().Count() < 1)
      {
        Console.WriteLine("Seeding Line");
        SeedLine();
      }
      else {
        Console.WriteLine("Aborting - Data already found");
      }
    }
    public void SeedLine()
    {
        List<Zone> ZonesData = new();

        foreach (var data in ZoneOpStationsSeedData){
            List<OpStation> _opStations = data.Value.Select(x => new OpStation() { StationName = x }).ToList();
            Zone _zone = new() { ZoneName = data.Key, OpStations = _opStations };
            ZonesData.Add(_zone);
        }

        try
        {
            _dbContext.Zone.AddRange(ZonesData);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred when saving changes: {ex.Message}");
        }
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