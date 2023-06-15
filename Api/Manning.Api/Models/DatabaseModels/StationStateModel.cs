using System.ComponentModel.DataAnnotations.Schema;

namespace Manning.Api.Models
{
  public class StationStateModel : BaseModel
  {
    [ForeignKey("StationID")]
    public int StationID { get; set; }
    [ForeignKey("OperatorID")]
    public int OperatorID { get; set; }
  }
}