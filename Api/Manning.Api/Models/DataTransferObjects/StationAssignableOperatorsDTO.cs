using Manning.Api.Models;

namespace Manning.Api.Models.DataTransferObjects
{
    public class StationAssignableOperatorsDTO
    {
      public List<Operator?> ValidOperators {get; set;} = new List<Operator?>();
      public List<Operator?> TrainingOperators {get; set;} = new List<Operator?>();
      
    }
}
