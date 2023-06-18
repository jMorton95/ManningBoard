using Manning.Api.Models;

namespace Manning.Api.Models.DataTransferObjects
{
    public class StationAssignableOperatorsDTO
    {
      public List<Operator> validOperators {get; set;}
      public List<Operator> trainingOperators {get; set;}
      
    }
}
