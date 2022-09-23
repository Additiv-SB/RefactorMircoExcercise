using FakeItEasy;
using NUnit.Framework;
using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
    [TestFixture]
    public class TurnTicketDispenserTests
    {
        [SetUp]
        public void Setup()
        {
            _turnNumberSequence = A.Fake<ITurnNumberSequence>();
            _ticketDispenser = new TicketDispenser(_turnNumberSequence);
        }

        private ITicketDispenser _ticketDispenser;
        private ITurnNumberSequence _turnNumberSequence;

        [Test]
        public void Should_ReturnTurnTicket_When_GetTurnTicketMethodCalled()
        {
            var expectedResult = new TurnTicket(0);
            var result = _ticketDispenser.GetTurnTicket();

            Assert.That(result.TurnNumber, Is.EqualTo(expectedResult.TurnNumber));
        }

        [Test]
        public void Should_ReturnTurnTicketType_When_GetTurnTicketMethodCalled()
        {
            var expectedType = typeof(TurnTicket);
            var result = _ticketDispenser.GetTurnTicket();

            Assert.That(result, Is.TypeOf(expectedType));
        }

        [Test]
        public void Should_ReturnTwoTurnTicketsWithDifferentTurnNumbers_When_GetTurnTicketMethodCalled()
        {
            var ticket1 = _ticketDispenser.GetTurnTicket();
            var ticket2 = _ticketDispenser.GetTurnTicket();

            Assert.That(ticket1.TurnNumber, Is.Not.EqualTo(ticket2.TurnNumber));
        }


        [Test]
        public void Should_ReturnTwoTurnTicketsWithDifferentTurnNumbers_When_GetTurnTicketMethodCalledByTwoTicketDispensers()
        {
            var ticketDispenser = new TicketDispenser(_turnNumberSequence);
            var ticket1 = ticketDispenser.GetTurnTicket();
            var ticket2 = _ticketDispenser.GetTurnTicket();

            Assert.That(ticket1.TurnNumber, Is.Not.EqualTo(ticket2.TurnNumber));
        }
    }
}