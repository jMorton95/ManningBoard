using Manning.Api.Models;

namespace Manning.Api.Models.DataTransferObjects
{
    public class OperatorAndTrainingDTO
    {
        public Operator Operator { get; set; }
        public int[] TrainingIDs { get; set; }
    }
}
