using System.ComponentModel.DataAnnotations;

namespace Manning.Api.Models
{
    public class Zone : BaseModel
    {
        [Required, StringLength(50)]
        public string? ZoneName { get; set; }
        public List<Station>? Stations { get; set; }
    }
}
