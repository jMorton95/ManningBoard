using ReactManningPoCAPI.Models;

namespace ReactManningPoCAPI.ViewModels
{
    public class OperatorAndTraining
    {
        public OperatorAndTraining(Operator _operator, List<int> _trainingIDs)
        {
            Operator = _operator;
            TrainingIDs = _trainingIDs;
        }

        public Operator Operator { get; set; }
        public List<int> TrainingIDs{ get; set; }
    }
}
