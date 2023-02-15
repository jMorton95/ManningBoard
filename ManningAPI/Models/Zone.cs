using System.ComponentModel.DataAnnotations;

namespace ReactManningPoCAPI.Models
{
    public class Zone : BaseModel
    {
        [Required, StringLength(50)]
        public string? ZoneName { get; set; }
        public List<OpStation>? OpStations { get; set; }
    }
}
