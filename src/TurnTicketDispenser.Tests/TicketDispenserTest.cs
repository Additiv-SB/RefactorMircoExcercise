using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
    // Notes
    // The TicketDispenser is testable without refactoring.
    // It would be worth to inject the dependency for TurnNumberSequence, to allow organize test cases even more flexible.
    // However, the DI would probably require to change TurnNumberSequence static members which would breach the clients depending on it.
    [TestFixture]
    public class TicketDispenserTest
    {
        [Test]
        public void GetTicketsTest()
        {
            TicketDispenser dispenser = new TicketDispenser();
            Assert.AreNotEqual(dispenser.GetTurnTicket().TurnNumber, dispenser.GetTurnTicket().TurnNumber);
            Assert.AreNotEqual(dispenser.GetTurnTicket().TurnNumber, dispenser.GetTurnTicket().TurnNumber);
        }

        [Test]
        public void GetTicketsFromDifferentDispensersTest()
        {
            Assert.AreNotEqual(new TicketDispenser().GetTurnTicket().TurnNumber, new TicketDispenser().GetTurnTicket().TurnNumber);
            Assert.AreNotEqual(new TicketDispenser().GetTurnTicket().TurnNumber, new TicketDispenser().GetTurnTicket().TurnNumber);
        }
    }
}
