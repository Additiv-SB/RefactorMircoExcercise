using System;
using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public sealed class TurnNumberSequence : ITurnNumberSequence
    {
        private static readonly Lazy<TurnNumberSequence> Lazy =
            new Lazy<TurnNumberSequence>(() => new TurnNumberSequence());

        private int _turnNumber;

        private TurnNumberSequence()
        {
        }

        public static TurnNumberSequence Instance => Lazy.Value;

        public int GetNextTurnNumber()
        {
            return _turnNumber++;
        }
    }
}