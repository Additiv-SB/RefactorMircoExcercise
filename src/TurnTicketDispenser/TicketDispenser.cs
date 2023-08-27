using Moq;
using System;

namespace TDDMicroExercises.TurnTicketDispenser
{
    /* Dependency Inversion Principle Violation:
    It was directly dependent on the static methods of TurnNumberSequence
    which made it hard to mock the TurnNumberSequence during testing.*/
    public class TicketDispenser
    {
        private readonly ITurnNumberSequence _turnNumberSequence;

        public TicketDispenser(ITurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }

        public TurnTicket GetTurnTicket()
        {
            int newTurnNumber = _turnNumberSequence.GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
