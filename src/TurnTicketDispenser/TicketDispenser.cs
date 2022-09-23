using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser: ITicketDispenser
    {
        public TurnTicket GetTurnTicket()
        {
            int newTurnNumber = TurnNumberSequence.GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
