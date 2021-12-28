using NUnit.Framework;
using TDDMicroExercises.TurnTicketDispenser;

namespace Tests
{
    [TestFixture]
    public class TicketDispenserTests
    {
        [Test]
        public void GetTurnTicket_ExpectedBehavior()
        {
            var ticketDispenser = new TicketDispenser();

            for (var i = 0; i < 3; i++)
            {
                var turnTicket = ticketDispenser.GetTurnTicket();
                Assert.AreEqual(i, turnTicket.TurnNumber);
            }
        }
    }
}