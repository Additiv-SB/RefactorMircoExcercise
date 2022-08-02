namespace TDDMicroExercises.TurnTicketDispenser
{
    internal sealed class TicketNumberProvider : ITicketNumberProvider
    {
        public int GetNextTurnNumber() => TurnNumberSequence.GetNextTurnNumber();
    }
}