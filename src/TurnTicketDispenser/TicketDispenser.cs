namespace TDDMicroExercises.TurnTicketDispenser
{
    internal sealed class TicketDispenser : ITicketDispenser
    {
        private readonly ITicketNumberProvider _ticketNumberProvider;

        public TicketDispenser(ITicketNumberProvider ticketNumberProvider) =>
            _ticketNumberProvider = ticketNumberProvider;

        public TurnTicket GetTurnTicket()
        {
            int newTurnNumber = _ticketNumberProvider.GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}