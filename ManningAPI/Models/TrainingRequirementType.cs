using System.ComponentModel.DataAnnotations;

namespace ManningApi.Models
{
    public class TrainingRequirementType : BaseModel
    {
        [Required, StringLength(50)]
        public string? TrainingType {  get; set; }
    }
}
