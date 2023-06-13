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
            Console.WriteLine("Adding Zones & OpStations");
            SeedLine();
        }
        else
        {
            Console.WriteLine("Skipped Zones & OpStations - Data Already Found");
        }

        if (_dbContext.Operator.ToList().Count() < 1)
        {
            Console.WriteLine("Adding Operators");
            SeedOperators();
        }
        else
        {
            Console.WriteLine("Skipped Operators - Data Already Found");
        }
    }
    public void SeedLine()
    {
        List<Zone> ZonesData = new();

        foreach (var kvp in ZoneOpStationsSeedData)
        {
            List<OpStation> _opStations = kvp.Value.Select(x => new OpStation() { StationName = x }).ToList();
            Zone _zone = new() { ZoneName = kvp.Key, OpStations = _opStations };
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
        List<Operator> OperatorData = new();
        foreach (var (ClockCardNumber, OperatorName, IsAdministrator) in OperatorSeedData)
        {
            OperatorData.Add(new()
            {
                ClockCardNumber = ClockCardNumber,
                OperatorName = OperatorName,
                IsAdministrator = IsAdministrator
            });
        }

        try
        {
            _dbContext.Operator.AddRange(OperatorData);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred when saving changes:  {ex.Message}");
        }
    }

    public void SeedTraining()
    {
        throw new NotImplementedException();
    }

    #region Data

    private readonly Dictionary<string, string[]> ZoneOpStationsSeedData = new()
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


    private readonly (int ClockCardNumber, string OperatorName, bool IsAdministrator)[] OperatorSeedData = new (int ClockCardNumber, string OperatorName, bool IsAdministrator)[]
    {
        (123456, "Josh Morton", true),
        (333222, "Jade Woodward", true),
        (789123, "Emily Rodriguez", false),
        (456789, "Michael Jenkins", false),
        (987654, "Sophia Thompson", true),
        (654321, "Oliver Lee", false),
        (741852, "Ava Turner", true),
        (852963, "Liam Adams", false),
        (159357, "Emma Collins", true),
        (258369, "Noah Butler", false),
        (369258, "Isabella Hall", true),
        (753951, "Mason Jackson", false),
        (951753, "Charlotte Patterson", true),
        (147852, "Ethan Anderson", false),
        (246813, "Mia Morris", true),
        (864209, "Alexander Nelson", false),
        (135790, "Avery Wright", true),
        (579314, "Harper Ramirez", false),
        (816703, "James Bennett", true)
    };
    #endregion
}