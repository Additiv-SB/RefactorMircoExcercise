using NUnit.Framework;
using TDDMicroExercises.TurnTicketDispenser;

namespace TDDMicroExercises.UnitTests.TurnTicketDispenser.Tests
{
    public class TicketDispenserTests
    {
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void GetTurnTicket_CalledInLoop_ReturnsNotDuplicatedCollection(int numberOfTimes)
        {
            var ticketDispenser = new TicketDispenser();

            var tickets = new List<int>();
            for (int i = 0; i < numberOfTimes; i++)
            {
                tickets.Add(ticketDispenser.GetTurnTicket().TurnNumber);
            }

            Assert.AreEqual(tickets.Distinct().Count(), numberOfTimes);
        }
    }
}
