using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManningApi.Models
{
    public class OpStation : BaseModel
    {
        [Required, StringLength(20)]
        public string? StationName { get; set; }
        [ForeignKey("ZoneID")]
        public int? ZoneID {  get; set; }
        public List<TrainingRequirement>? TrainingRequirements { get; set; }
    }
}
