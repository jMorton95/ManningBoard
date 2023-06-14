using Manning.Api.Models;

namespace Manning.Api.Models.DataTransferObjects
{
    public class ClockedInOperator
    {
        public Operator? CurrentOperator { get; set; }
        public string? JsonWebToken { get; set; }
        public int SessionID { get; set; }
        public ClockedInOperator(Operator currentOperator, string jsonWebToken, int sessionID)
        {
            CurrentOperator = currentOperator;
            JsonWebToken = jsonWebToken;
            SessionID = sessionID;
        }


    }
}
