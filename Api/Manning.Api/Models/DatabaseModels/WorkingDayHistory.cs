using System.ComponentModel.DataAnnotations;

namespace Manning.Api.Models
{
    public class WorkingDayHistory : BaseModel
    {
        [Required]
        public DateTime ShiftDate { get; set; }
        [Required]
        public string? ShiftName { get; set; }
        public int StationID { get; set; }
        public int OperatorID { get; set; }
        public bool IsTrainee { get; set; }

    }
}
