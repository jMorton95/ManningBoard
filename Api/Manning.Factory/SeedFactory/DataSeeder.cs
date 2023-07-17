namespace Manning.Factory.SeedFactory;
using System.Linq;
using Manning.Api.Models;
using Manning.Api.Repositories;
using static Manning.Factory.SeedFactory.Data;
using static Manning.Factory.SeedFactory.SeedDataStrategy;

public class DataSeeder
{
    private readonly ManningDbContext _dbContext;

    public DataSeeder(ManningDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void RunDataSeed()
    {
        List<SeedDataRegistry> seedDataRegistries = new()
        {
          new SeedDataRegistry<Zone>(() => _dbContext.Zone, SeedLine, "Zone"),
          new SeedDataRegistry<Operator>(() => _dbContext.Operator, SeedOperators, "Operators"),
          new SeedDataRegistry<AvatarModel>(() => _dbContext.AvatarModels, SeedAvatars, "Avatar Models"),
          new SeedDataRegistry<TrainingRequirement>(() => _dbContext.TrainingRequirement, SeedTraining, "Training Requirements"),
          new SeedDataRegistry<OperatorCompletedTraining>(() => _dbContext.OperatorCompletedTraining, () => SeedCompletedTraining(5), "Operator Completed Training"),
          //new SeedDataRegistry<ShiftType>(() => _dbContext.ShiftType, SeedShiftType, "Shift Type"),
        };

        SeedStrategy(seedDataRegistries);
    }
    public void SeedLine()
    {
        List<Zone> ZonesData = new();

        foreach (var kvp in ZoneStationsSeedData)
        {
            List<Station> _stations = kvp.Value.Select(x => new Station() { StationName = x }).ToList();
            Zone _zone = new() { ZoneName = kvp.Key, Stations = _stations };
            ZonesData.Add(_zone);
        }

        try
        {
            _dbContext.Zone.AddRange(ZonesData);
            _dbContext.SaveChanges();
            Console.WriteLine($"Succesfully added {ZoneStationsSeedData.Count} zones and {ZoneStationsSeedData.Values.SelectMany(x => x).Count()} stations");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred when saving changes: {ex.Message}");
        }
    }

    public void SeedOperators()
    {
        List<Operator> OperatorData = OperatorSeedData.Select(x => new Operator() { ClockCardNumber = x.ClockCardNumber, OperatorName = x.OperatorName, IsAdministrator = x.IsAdministrator }).ToList();

        try
        {
            _dbContext.Operator.AddRange(OperatorData);
            _dbContext.SaveChanges();
            Console.WriteLine($"Succesfully added {OperatorData.Count} operators");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred when saving changes:  {ex.Message}");
        }
    }

    public void SeedAvatars() {
      
      List<AvatarModel> AvatarData = new ();

      foreach(var item in AvatarSeedData)
      {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"assets/{item.fileName}");
        Console.WriteLine($"{path} {item.fileName}");

        if (!File.Exists(path))
        {
          Console.WriteLine($"Could not find: {item.fileName}");
        } 
        else
        {
          AvatarModel avatar = new()
          {
            FileName = item.fileName,
            FileContent = File.ReadAllBytes(path),
            ContentType = "image/png",
            OperatorID = item.operatorID,
          };
          AvatarData.Add(avatar);
        }
      }

       try
        {
            _dbContext.AvatarModels.AddRange(AvatarData);
            _dbContext.SaveChanges();
            Console.WriteLine($"Succesfully added {AvatarData.Count} Avatars!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred when saving Avatar Data: {ex.Message}");
        }
    
    }

    public void SeedTraining()
    {
        List<Station> Stations = _dbContext.Station.ToList();

        List<TrainingRequirement> TrainingRequirementData = new();

        Random random = new();

        foreach (var requirement in TrainingRequirementSeedData)
        {
            int randId = random.Next(0, Stations.Count);

            TrainingRequirementData.Add(new()
            {
                RequirementDescription = requirement,
                StationID = Stations[randId].ID
            });

            Stations.RemoveAt(randId);
        }

        try
        {
            _dbContext.TrainingRequirement.AddRange(TrainingRequirementData);
            _dbContext.SaveChanges();
            Console.WriteLine($"Succesfully added {TrainingRequirementData.Count} training requirements");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred when saving Training Requirements: {ex.Message}");
        }
    }

    public void SeedCompletedTraining(int recordsToSeed)
    {
        List<Operator> operators = _dbContext.Operator.Take(recordsToSeed).ToList();
        List<TrainingRequirement> trainingRequirements = _dbContext.TrainingRequirement.Take(recordsToSeed).ToList();

        List<OperatorCompletedTraining> completedTrainingToSeed = new();

        for (int i = 0; i < recordsToSeed; i++)
        {
            completedTrainingToSeed.Add(new()
            {
                OperatorID = operators[i].ID,
                TrainerClockCardNumber = operators[i].ClockCardNumber,
                TrainingRequirementID = trainingRequirements[i].ID,
            });
        }

        try
        {
            _dbContext.OperatorCompletedTraining.AddRange(completedTrainingToSeed);
            _dbContext.SaveChanges();
            Console.WriteLine($"Succesfully added {completedTrainingToSeed.Count} completed training");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred when saving Operator Completed Training: {ex.Message}");
        }
    }

    /*public void SeedShiftType()
    {
        List<ShiftType> shiftsToSeed = ShiftTypeSeedData.Select(x => new ShiftType() { ShiftName = x }).ToList();

      try
      {
        _dbContext.ShiftType.AddRange(shiftsToSeed);
        _dbContext.SaveChanges();
        Console.WriteLine($"Succesfully added {shiftsToSeed.Count} shift types");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occured when saving Shift Type Data: {ex.Message}");
      }
    }*/

}