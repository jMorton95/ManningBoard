using System.ComponentModel.DataAnnotations;

namespace ManningApi.Models
{
    public class ShiftType : BaseModel
    {
        [Required, StringLength(50)]
        public string? ShiftName { get; set; }
    }
}
