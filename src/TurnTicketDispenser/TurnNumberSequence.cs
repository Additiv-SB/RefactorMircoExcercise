namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TurnNumberSequence : ITurnNumberSequence
    {
        private static int _turnNumber = 0;

        public int GetNextTurnNumber()
        {
            return _turnNumber++;
        }
    }
}
