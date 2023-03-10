using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactManningPoCAPI.Models
{
    public class WorkingDayHistory : BaseModel
    {
        [Required, Column(TypeName = "DateTime2")]
        public DateTime ShiftDate { get; set; }
        [ForeignKey("OperatorID")]
        public int OperatorID {  get; set; }
        [ForeignKey("OpStationID")]
        public int OpStationID { get; set; }
        [ForeignKey("ShiftID")]
        public int ShiftID { get; set; }
        public Operator? Operator { get; set; }
        public OpStation? OpStation {  get; set; }
        public ShiftType? Shift { get; set; }

    }
}
