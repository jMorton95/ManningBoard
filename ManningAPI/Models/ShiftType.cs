using System.ComponentModel.DataAnnotations;

namespace ReactManningPoCAPI.Models
{
    public class ShiftType : BaseModel
    {
        [Required, StringLength(50)]
        public string? ShiftName { get; set; }
    }
}
