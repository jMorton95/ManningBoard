using System.ComponentModel.DataAnnotations;

namespace Manning.Api.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int ID { get; set; }
    }
}
