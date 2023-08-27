using System;
namespace TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TurnTicketAndSequenceClient
    {
        // A class with the only goal of simulating a dependencies on 
        // TurnNumberSequence and TurnTicket that have impact on the refactoring.
        private readonly ITurnNumberSequence _turnNumberSequence;

        public TurnTicketAndSequenceClient(ITurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }
        public TurnTicketAndSequenceClient()
        {
			var turnTicket1 = new TurnTicket(_turnNumberSequence.GetNextTurnNumber());
			var turnTicket2 = new TurnTicket(_turnNumberSequence.GetNextTurnNumber());
			var turnTicket3 = new TurnTicket(_turnNumberSequence.GetNextTurnNumber());
		}
    }
}
