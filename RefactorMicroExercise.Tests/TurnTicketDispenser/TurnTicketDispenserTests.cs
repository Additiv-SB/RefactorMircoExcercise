using TDDMicroExercises.TurnTicketDispenser;
using Xunit;

namespace RefactorMicroExercise.Tests.TurnTicketDispenser
{
    public class TurnTicketDispenserTests
    {
        [Fact]
        public void GetTurnTicket_ReturnsNotNull()
        {
            TicketDispenser ticketDispenser = new TicketDispenser();

            TurnTicket turnTicket = ticketDispenser.GetTurnTicket();

            Assert.NotNull(turnTicket);
        }

        [Fact]
        public void GetTurnTicket_TurnTicketWithRightNumber()
        {
            TicketDispenser ticketDispenser = new TicketDispenser();

            for(int i=0; i < 5; i++)
            {
                TurnTicket turnTicket = ticketDispenser.GetTurnTicket();
                Assert.Equal(i, turnTicket.TurnNumber);
            }
        }

    }
}
