using System.ComponentModel.DataAnnotations;

namespace ReactManningPoCAPI.Models
{
    public class Operator : BaseModel
    {
        [Required, RegularExpression(@"^[0-9]{6}$")]
        public int ClockCardNumber { get; set; }
        [Required, StringLength(50)]
        public string? OperatorName { get; set; }
    }
}
