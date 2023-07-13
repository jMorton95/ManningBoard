namespace Manning.Api.Models.DataTransferObjects
{
  public class StationStateDTO
  {
    public Station? Station { get; set; }
    public OperatorAndAvatarDTO? OperatorAndAvatar { get; set; }
    public OperatorAndAvatarDTO? TraineeAndAvatar { get; set;}
  }
}