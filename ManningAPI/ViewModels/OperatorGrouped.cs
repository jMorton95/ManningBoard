using ReactManningPoCAPI.Models;

namespace ReactManningPoCAPI.ViewModels
{
    public class OperatorGrouped
    {
        public enum StatusColor {
            Green, Yellow, Red
        }
        public OperatorGrouped(Operator _operator, StatusColor color)
        {
            @operator = _operator;
            Color = color;
        }

        public Operator @operator{ get; set; }
        public StatusColor Color { get; set;}

    }
}
