using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manning.Api.Models
{
    public class WorkingDayHistory : BaseModel
    {
        [Required]
        public DateTime ShiftDate { get; set; }
        [ForeignKey("OperatorID")]
        public int OperatorID { get; set; }
        [ForeignKey("StationID")]
        public int StationID { get; set; }
        [ForeignKey("ShiftID")]
        public int ShiftID { get; set; }
        public Operator? Operator { get; set; }
        public Station? Station { get; set; }
        public ShiftType? Shift { get; set; }

    }
}
