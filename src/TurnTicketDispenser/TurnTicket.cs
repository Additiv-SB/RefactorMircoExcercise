namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TurnTicket
    {
        public int TurnNumber { get; set; }
        public TurnTicket(int turnNumber)
        {
            TurnNumber = turnNumber;
        }
    }
}