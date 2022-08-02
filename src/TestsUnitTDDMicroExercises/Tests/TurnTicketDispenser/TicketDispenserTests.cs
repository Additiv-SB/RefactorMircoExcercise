using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using TDDMicroExercises.TurnTicketDispenser;
using TestsUnitTDDMicroExercises.Common.Fixtures;

namespace TestsUnitTDDMicroExercises.Tests.TurnTicketDispenser
{
    [TestFixture]
    internal sealed class TicketDispenserTests
    {
        private readonly IFixture _fixture;

        public TicketDispenserTests()
        {
            _fixture = new Fixture();
            _fixture.Register(() => TicketNumberProviderFixture.WithSequentialTicketNumbers());

            _fixture.Register(() => new Queue<int>(Enumerable.Range(0, 1_000)));
        }

        [Test]
        public void TicketNumberStartsFromZero() =>
            _fixture.Create<TicketDispenser>().GetTurnTicket().TurnNumber.Should().Be(0);

        [Test]
        public void NextTicketHasItsNumberGreaterThanPreviousTicketInSequence()
        {
            ITicketDispenser ticketDispenser = _fixture.Create<TicketDispenser>();

            TurnTicket firstTicket = ticketDispenser.GetTurnTicket();
            TurnTicket secondTicket = ticketDispenser.GetTurnTicket();

            secondTicket.TurnNumber.Should().BeGreaterThan(firstTicket.TurnNumber);
        }

        [Test]
        public void ConsecutiveTicketsNumbersDifferBuOne()
        {
            ITicketDispenser ticketDispenser = _fixture.Create<TicketDispenser>();

            TurnTicket firstTicket = ticketDispenser.GetTurnTicket();
            TurnTicket secondTicket = ticketDispenser.GetTurnTicket();

            int differenceBetweenConsecutiveTicketsNumbers = secondTicket.TurnNumber - firstTicket.TurnNumber;

            differenceBetweenConsecutiveTicketsNumbers.Should().Be(1);
        }
    }
}