namespace TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TurnNumberSequenceClient
    {
		// A class with the only goal of simulating a dependency on TurnNumberSequence
		// that has impact on the refactoring.

		public TurnNumberSequenceClient()
        {
            int nextUniqueTicketNumber;
            var turnNumberSequence = TurnNumberSequence.Instance;
            nextUniqueTicketNumber = turnNumberSequence.GetNextTurnNumber();
			nextUniqueTicketNumber = turnNumberSequence.GetNextTurnNumber();
			nextUniqueTicketNumber = turnNumberSequence.GetNextTurnNumber();
		}
    }
}
