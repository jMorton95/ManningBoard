namespace Manning.Api.Models.DataTransferObjects
{
  public class ZoneStateDTO
  {
    public Zone? Zone{ get; set; }
    public List<StationStateDTO>? StationStateDTOs { get; set; }
  }
}