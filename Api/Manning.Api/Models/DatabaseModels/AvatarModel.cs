using System.ComponentModel.DataAnnotations.Schema;

namespace Manning.Api.Models
{
    public class AvatarModel : BaseModel
    {
        public string? FileName { get; set; }
        public byte[]? FileContent { get; set; }
        public string? ContentType { get; set; }
        [ForeignKey("OperatorID")]
        public int? OperatorID { get; set; }
    }
}
