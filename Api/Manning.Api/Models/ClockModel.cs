using System.ComponentModel.DataAnnotations;

namespace Manning.Api.Models
{
    public class ClockModel : BaseModel
    {
        [Required, RegularExpression(@"^[0-9]{6}$")]
        public int? ClockCardNumber { get; set; }
        [Required, StringLength(50)]
        public string? OperatorName { get; set; }
        public DateTime? ClockInTime { get; set; }
        public DateTime? ClockOutTime { get; set; }
    }

}
