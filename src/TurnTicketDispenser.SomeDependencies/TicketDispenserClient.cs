using System;
namespace TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TicketDispenserClient
    {
        // A class with the only goal of simulating a dependency on TicketDispenser
        // that has impact on the refactoring.
        private readonly TicketDispenser _ticketDispenser;

        public TicketDispenserClient(TicketDispenser ticketDispenser)
        {
            _ticketDispenser = ticketDispenser;
        }
        public TicketDispenserClient()
        {
            _ticketDispenser.GetTurnTicket();
            _ticketDispenser.GetTurnTicket();
            _ticketDispenser.GetTurnTicket();
		}
    }
}
