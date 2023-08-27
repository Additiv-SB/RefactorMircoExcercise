using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenserFactory
    {
        private readonly ITurnNumberSequence _turnNumberSequence;

        public TicketDispenserFactory(ITurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }

        public TicketDispenser CreateTicketDispenser()
        {
            return new TicketDispenser(_turnNumberSequence);
        }
    }
}
