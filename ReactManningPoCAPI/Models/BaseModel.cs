using System.ComponentModel.DataAnnotations;

namespace ReactManningPoCAPI.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int ID { get; set; }
    }
}
