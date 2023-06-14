namespace Manning.Api.Models
{
  public class AssignedOperatorsModel : BaseModel
  {
    public Operator? Operator { get; set; }
    public OpStation? OpStation { get; set; }
    public Operator? TrainingOperator { get; set; }
  }
}