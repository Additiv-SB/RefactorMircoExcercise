using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TDDMicroExercises.TurnTicketDispenser;

namespace TDDMicroExcercises.Tests
{
    public class TurnTicketDispenserTests
    {
        private ITicketDispenser _ticketDispenser;
        private ITicketDispenser _ticketDispenser2;

        [SetUp]
        public void Setup()
        {
            _ticketDispenser = new TicketDispenser();
            _ticketDispenser2 = new TicketDispenser();
        }

        [Test]
        public void TestIfTicketNumberIsZero()
        {
            var ticket = _ticketDispenser.GetTurnTicket();
            Assert.AreNotEqual(0, ticket.TurnNumber, "Initial ticket number is 0!");
        }

        [Test]
        public void TestNextTicketNumber()
        {
            var ticket = _ticketDispenser.GetTurnTicket();
            var nextTicket = _ticketDispenser.GetTurnTicket();
            Assert.Greater(nextTicket.TurnNumber, ticket.TurnNumber, "Next ticket number is smaller than previous");
        }

        [Test]
        public void TestIfTicketNumbersAreUnique()
        {
            var ticketList = new List<TurnTicket>();

            for (int i = 0; i < 10; i++)
            {
                ticketList.Add(_ticketDispenser.GetTurnTicket());
            }

            CollectionAssert.AllItemsAreUnique(ticketList, "Tickets are not unique");
        }

        [Test]
        public void TestIfTicketNumbersAreGeneratedInOrder()
        {
            var ticketListTurnNumbers = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                ticketListTurnNumbers.Add(_ticketDispenser.GetTurnTicket().TurnNumber);
            }

            // Enumerable.Range will create a new enumerable
            // with values ranging from .First() to .Last(),
            // i.e. [1, 2, 3, 4]
            Assert.IsTrue(Enumerable.Range(ticketListTurnNumbers.First(), ticketListTurnNumbers.Count()).ToList()
                          .SequenceEqual(ticketListTurnNumbers), 
                          "Ticket Numbers Are Not In Order");

        }

        [Test]
        public void TestMultipleDispensers()
        {
            var ticket1 = _ticketDispenser.GetTurnTicket();

            var ticket2 = _ticketDispenser2.GetTurnTicket();

            Assert.AreNotEqual(ticket1, ticket2, "Ticket numbers from different dispensers are equal!");
        }
    }
}