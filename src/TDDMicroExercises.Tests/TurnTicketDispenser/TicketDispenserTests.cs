using FluentAssertions;
using TDDMicroExercises.TurnTicketDispenser;
using Xunit;

namespace TDDMicroExercises.Tests.TurnTicketDispenser
{
    public class TicketDispenserTests
    {
        [Fact]
        public void GetTurnTicket_WhenCalled_ReturnsNotNull() 
        {
            var ticketDispenser = new TicketDispenser();

            TurnTicket turnTicket = ticketDispenser.GetTurnTicket();

            turnTicket.Should().NotBeNull();
        } 
        
        [Fact]
        public void GetTurnTicket_WhenCalledMultipleTimes_ReturnsEntityWithRightTurnNumber() 
        {
            var ticketDispenser = new TicketDispenser();
            var expectedFirstTurnNumber = 0;
            var expectedSecondTurnNumber = 1;

            TurnTicket firstTurnTicket = ticketDispenser.GetTurnTicket();
            TurnTicket secondTurnTicket = ticketDispenser.GetTurnTicket();

            firstTurnTicket.TurnNumber.Should().Be(expectedFirstTurnNumber);
            secondTurnTicket.TurnNumber.Should().Be(expectedSecondTurnNumber);
        }
    }
}
