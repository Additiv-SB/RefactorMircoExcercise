using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using TDDMicroExercises.TurnTicketDispenser;

namespace TestsUnitTDDMicroExercises.Tests.TurnTicketDispenser
{
    [TestFixture]
    internal sealed class TicketDispenserTests
    {
        [Test]
        [AutoData]
        public void TicketNumberStartsFromZero(TicketDispenser ticketDispenser) =>
            ticketDispenser.GetTurnTicket().TurnNumber.Should().Be(0);

        [Test]
        [AutoData]
        public void NextTicketHasItsNumberGreaterThanPreviousTicketInSequence(TicketDispenser ticketDispenser)
        {
            TurnTicket firstTicket = ticketDispenser.GetTurnTicket();
            TurnTicket secondTicket = ticketDispenser.GetTurnTicket();

            secondTicket.TurnNumber.Should().BeGreaterThan(firstTicket.TurnNumber);
        }

        [Test]
        [AutoData]
        public void ConsecutiveTicketsNumbersDifferBuOne(TicketDispenser ticketDispenser)
        {
            TurnTicket firstTicket = ticketDispenser.GetTurnTicket();
            TurnTicket secondTicket = ticketDispenser.GetTurnTicket();

            int differenceBetweenConsecutiveTicketsNumbers = secondTicket.TurnNumber - firstTicket.TurnNumber;

            differenceBetweenConsecutiveTicketsNumbers.Should().Be(1);
        }

        [Test]
        [AutoData]
        public void EachTicketHasUniqueNumber(List<TicketDispenser> ticketDispensers, [Range(1, 1_000, 100)] int ticketsGeneratedPerDispenser)
        {
            IList<int> turnTicketsNumbers = new List<int>();

            Parallel.ForEach(
                ticketDispensers,
                ticketDispenser =>
                {
                    for (int i = 0; i < ticketsGeneratedPerDispenser; i++)
                        turnTicketsNumbers.Add(ticketDispenser.GetTurnTicket().TurnNumber);
                });

            turnTicketsNumbers.Should().OnlyHaveUniqueItems();
        }
    }
}