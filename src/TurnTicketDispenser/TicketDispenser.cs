namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser 
    {
        public TurnTicket GetTurnTicket()
        {
            int newTurnNumber = TurnNumberSequence.GetNextTurnNumber();
            return new TurnTicket(newTurnNumber);
        }
    }
}
