using TDDMicroExercises.TurnTicketDispenser;
using Xunit;

namespace RefactorMicroExercise.Tests.TurnTicketDispenser
{
    public class TurnTicketDispenserUnitTests
    {
        [Fact]
        public void TGetTurnTicket_ReturnsNotNull()
        {
            TicketDispenser ticketDispenser = new TicketDispenser();

            TurnTicket turnTicket = ticketDispenser.GetTurnTicket();

            Assert.NotNull(turnTicket);
        }

        [Fact]
        public void GetTurnTicket_ShouldReturnTicketWithRightNumber()
        {
            TicketDispenser ticketDispenser = new TicketDispenser();

            for (int i = 0; i < 5; i++)
            {
                TurnTicket turnTicket = ticketDispenser.GetTurnTicket();
                Assert.Equal(i, turnTicket.TurnNumber);
            }
        }

    }
}