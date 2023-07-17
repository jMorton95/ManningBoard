using System.ComponentModel.DataAnnotations;

namespace Manning.Api.Models
{
    public class WorkingDayHistory : BaseModel
    {
        [Required]
        public DateTime ShiftDate { get; set; }
        [Required]
        public string? ShiftName { get; set; }
        public StationStateModel? StationState { get; set; }

    }
}
