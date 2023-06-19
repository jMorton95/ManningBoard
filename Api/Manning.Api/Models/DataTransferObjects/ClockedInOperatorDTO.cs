namespace Manning.Api.Models.DataTransferObjects
{
    public class ClockedInOperatorDTO
    {
        public Operator CurrentOperator { get; set; }
        public string JsonWebToken { get; set; }
        public int SessionID { get; set; }
        public ClockedInOperatorDTO(Operator currentOperator, string jsonWebToken, int sessionID)
        {
            CurrentOperator = currentOperator;
            JsonWebToken = jsonWebToken;
            SessionID = sessionID;
        }
    }
}
