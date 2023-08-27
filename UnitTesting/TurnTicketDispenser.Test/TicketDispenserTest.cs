using Moq;
using TDDMicroExercises.TurnTicketDispenser;

namespace UnitTesting.TurnTicketDispenser.Test
{
    //Testing the TicketDispenser class using mock implementation of ITurnNumberSource

    [TestFixture]
    public class TicketDispenserTest
    {
        [Test]
        public void Dispenser_ShouldReturnNonNegativeTicketTurnNumber()
        {
            var mockTurnNumberSequence = new Mock<ITurnNumberSequence>();
            mockTurnNumberSequence.Setup(seq => seq.GetNextTurnNumber()).Returns(1);

            var dispenser = new TicketDispenser(mockTurnNumberSequence.Object);
            var ticket = dispenser.GetTurnTicket();

            Assert.That(ticket.TurnNumber, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void Dispenser_ShouldReturnSubsequentTicketTurnNumberEveryTime()
        {
            var mockTurnNumberSequence = new Mock<ITurnNumberSequence>();
            mockTurnNumberSequence.SetupSequence(seq => seq.GetNextTurnNumber())
                .Returns(1)
                .Returns(2)
                .Returns(3);

            var ticketDispenser = new TicketDispenser(mockTurnNumberSequence.Object);

            var ticket1 = ticketDispenser.GetTurnTicket();
            var ticket2 = ticketDispenser.GetTurnTicket();
            var ticket3 = ticketDispenser.GetTurnTicket();

            Assert.AreEqual(1, ticket1.TurnNumber);
            Assert.AreEqual(2, ticket2.TurnNumber);
            Assert.AreEqual(3, ticket3.TurnNumber);
        }

        [Test]
        public void MultipleDispensers_ShouldReturnSubsequentTicketTurnNumber()
        {
            var mockTurnNumberSequence = new Mock<ITurnNumberSequence>();
            mockTurnNumberSequence.SetupSequence(seq => seq.GetNextTurnNumber())
                .Returns(11)
                .Returns(12);

            var dispenser1 = new TicketDispenser(mockTurnNumberSequence.Object);
            var dispenser2 = new TicketDispenser(mockTurnNumberSequence.Object);

            var ticket1 = dispenser1.GetTurnTicket();
            var ticket2 = dispenser2.GetTurnTicket();

            Assert.AreEqual(11, ticket1.TurnNumber);
            Assert.AreEqual(12, ticket2.TurnNumber);
        }

        [Test]
        public void MultipleDispensers_ShouldReturnDistinctTicketTurnNumber()
        {
            var turnNumberSequence = new TurnNumberSequence();
            var dispenserFactory = new TicketDispenserFactory(turnNumberSequence);

            var dispenser1 = dispenserFactory.CreateTicketDispenser();
            var dispenser2 = dispenserFactory.CreateTicketDispenser();

            var ticket1 = dispenser1.GetTurnTicket();
            var ticket2 = dispenser2.GetTurnTicket();

            Assert.That(ticket1.TurnNumber, Is.Not.EqualTo(ticket2.TurnNumber));
        }
    }
}
