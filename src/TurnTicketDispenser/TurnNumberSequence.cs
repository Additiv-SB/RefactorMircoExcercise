using System;
using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public sealed class TurnNumberSequence: ITurnNumberSequence
    {
        private int _turnNumber = 0;

        private static readonly Lazy<TurnNumberSequence> Lazy =
            new Lazy<TurnNumberSequence>(() => new TurnNumberSequence());

        public static TurnNumberSequence Instance => Lazy.Value;

        private TurnNumberSequence()
        { }

        public int GetNextTurnNumber()
        {
            return _turnNumber++;
        }
    }
}
