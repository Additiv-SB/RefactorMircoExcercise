namespace TDDMicroExercises.TurnTicketDispenser
{
    public sealed class TurnTicket
    {
        private readonly int _turnNumber;

        public TurnTicket(int turnNumber)
        {
            _turnNumber = turnNumber;
        }

        public int TurnNumber
        {
            get { return _turnNumber; }
        }

    }
}