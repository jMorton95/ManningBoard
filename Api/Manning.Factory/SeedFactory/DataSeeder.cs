namespace Manning.Factory.SeedFactory;

using System.Security.Cryptography.X509Certificates;
using Manning.Api.Models;
using Manning.Api.Repositories;
using static Manning.Factory.SeedFactory.Data;

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

        if (_dbContext.TrainingRequirement.ToList().Count() <  1) {
          Console.WriteLine("Adding Training Requirements");
          SeedTraining();
        }
        else
        {
          Console.WriteLine("Skipped Training Requirements - Data Already Found");
        }

        if (_dbContext.OperatorCompletedTraining.ToList().Count() <  1) {
          Console.WriteLine("Adding Training Requirements");
          SeedCompletedTraining(5);
        }
        else
        {
          Console.WriteLine("Skipped Completed Training - Data Already Found");
        }
    }
    public void SeedLine()
    {
        List<Zone> ZonesData = new();

        foreach (var kvp in ZoneOpStationsSeedData)
        {
            List<Station> _opStations = kvp.Value.Select(x => new Station() { StationName = x }).ToList();
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
      List<Station> OpStations = _dbContext.Station.ToList(); 

      List<TrainingRequirement> TrainingRequirementData = new();

      Random random = new();

      foreach (var requirement in TrainingRequirementSeedData)
      {
        int randId = random.Next(0, OpStations.Count);

        TrainingRequirementData.Add(new()
        {
          RequirementDescription = requirement,
          OpStationID = OpStations[randId].ID
        });

        OpStations.RemoveAt(randId);
      }

      try 
      {
        _dbContext.TrainingRequirement.AddRange(TrainingRequirementData);
        _dbContext.SaveChanges();
      }
      catch (Exception ex) {
        Console.WriteLine($"An error occurred when saving Training Requirements: {ex.Message}" );
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
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred when saving Operator Completed Training: {ex.Message}");
      }
    }

}