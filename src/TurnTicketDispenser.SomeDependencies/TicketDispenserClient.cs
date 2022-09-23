namespace TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TicketDispenserClient
    {
		// A class with the only goal of simulating a dependency on TicketDispenser
		// that has impact on the refactoring.

		public TicketDispenserClient()
        {
            var turnNumberSequence = TurnNumberSequence.Instance;
			new TicketDispenser(turnNumberSequence).GetTurnTicket();
			new TicketDispenser(turnNumberSequence).GetTurnTicket();
			new TicketDispenser(turnNumberSequence).GetTurnTicket();
		}
    }
}
