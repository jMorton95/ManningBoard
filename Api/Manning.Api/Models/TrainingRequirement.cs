using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manning.Api.Models
{
    public class TrainingRequirement : BaseModel
    {
        [Required, StringLength(255)]
        public string? RequirementDescription { get; set; }
        [ForeignKey("OpStationID")]
        public int OpStationID { get; set; }
    }
}
