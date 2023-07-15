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
        public void ReturnTurnTicket_When_GetTurnTicketMethodCalled()
        {
            var turnCount = 1;
            var response = new TurnTicket(turnCount);
            A.CallTo(() => _turnNumberSequence.GetNextTurnNumber()).Returns(turnCount);
            var result = _ticketDispenser.GetTurnTicket();

            Assert.That(result.TurnNumber, Is.EqualTo(response.TurnNumber));
        }

        [Test]
        public void ReturnTurnTicketType_When_GetTurnTicketMethodCalled()
        {
            var response = typeof(TurnTicket);
            var result = _ticketDispenser.GetTurnTicket();

            Assert.That(result, Is.TypeOf(response));
        }

        [Test]
        public void CallGetGetNextTurnNumber_When_GetTurnTicketMethodCalled()
        {
            _ticketDispenser.GetTurnTicket();

            A.CallTo(() => _turnNumberSequence.GetNextTurnNumber()).MustHaveHappened(1,Times.Exactly);
        }



        [Test]
        public void ReturnTwoTurnTicketsWithDifferentTurnNumbers_When_GetTurnTicketMethodCalled()
        {
            A.CallTo(() => _turnNumberSequence.GetNextTurnNumber()).Returns(1);
            var ticket1 = _ticketDispenser.GetTurnTicket();

            A.CallTo(() => _turnNumberSequence.GetNextTurnNumber()).Returns(2);
            var ticket2 = _ticketDispenser.GetTurnTicket();


            Assert.That(ticket1.TurnNumber, Is.Not.EqualTo(ticket2.TurnNumber));
        }


        [Test]
        public void ReturnTwoTurnTicketsWithDifferentTurnNumbers_When_GetTurnTicketMethodCalledByTwoTicketDispensers()
        {
            var ticketDispenser = new TicketDispenser(_turnNumberSequence);
            A.CallTo(() => _turnNumberSequence.GetNextTurnNumber()).Returns(1);
            var ticket1 = ticketDispenser.GetTurnTicket();
            A.CallTo(() => _turnNumberSequence.GetNextTurnNumber()).Returns(2);
            var ticket2 = _ticketDispenser.GetTurnTicket();

            Assert.That(ticket1.TurnNumber, Is.Not.EqualTo(ticket2.TurnNumber));
        }
    }
}