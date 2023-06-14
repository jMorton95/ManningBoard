namespace Manning.Api.Models
{
  public class AssignedOperatorsModel : BaseModel
  {
    public Operator? Operator { get; set; }
    public Station? Station { get; set; }
  }
}