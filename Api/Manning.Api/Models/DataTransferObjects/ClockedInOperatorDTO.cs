namespace Manning.Api.Models.DataTransferObjects
{
    public class ClockedInOperatorDTO
    {
        public Operator CurrentOperator { get; set; }
        public int SessionID { get; set; }
        public ClockedInOperatorDTO(Operator currentOperator, int sessionID)
        {
            CurrentOperator = currentOperator;
            SessionID = sessionID;
        }
    }
}
