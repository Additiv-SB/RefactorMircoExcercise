namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser
    {
        public TurnTicket GetTurnTicket()
        {
            var newTurnNumber = TurnNumberSequence.GetNextTurnNumber();
            return new TurnTicket(newTurnNumber);
        }
    }
}
