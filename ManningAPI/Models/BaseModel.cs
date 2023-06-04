using System.ComponentModel.DataAnnotations;

namespace ManningApi.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int ID { get; set; }
    }
}
