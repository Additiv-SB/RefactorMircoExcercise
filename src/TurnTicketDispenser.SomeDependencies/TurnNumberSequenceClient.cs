using System;
namespace TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TurnNumberSequenceClient
    {
        private readonly ITurnNumberSequence _turnNumberSequence;

        public TurnNumberSequenceClient(ITurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }

        // A class with the only goal of simulating a dependency on TurnNumberSequence
        // that has impact on the refactoring.

        public TurnNumberSequenceClient()
        {
            int nextUniqueTicketNumber;
            nextUniqueTicketNumber = _turnNumberSequence.GetNextTurnNumber();
            nextUniqueTicketNumber = _turnNumberSequence.GetNextTurnNumber();
            nextUniqueTicketNumber = _turnNumberSequence.GetNextTurnNumber();
        }
    }
}
