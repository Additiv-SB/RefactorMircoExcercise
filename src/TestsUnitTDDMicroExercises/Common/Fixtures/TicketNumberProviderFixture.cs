using System.Collections.Generic;
using System.Linq;
using Moq;
using TDDMicroExercises.TurnTicketDispenser;

namespace TestsUnitTDDMicroExercises.Common.Fixtures
{
    internal static class TicketNumberProviderFixture
    {
        public static ITicketNumberProvider WithSequentialTicketNumbers(
            int ticketNumberFloor = 0, int ticketNumberCeiling = 100)
        {
            var ticketNumberProviderMock = new Mock<ITicketNumberProvider>();

            var ticketNumbersSequence = new Queue<int>(Enumerable.Range(ticketNumberFloor, ticketNumberCeiling));

            ticketNumberProviderMock
               .Setup(mockedTicketNumberProvider => mockedTicketNumberProvider.GetNextTurnNumber())
               .Returns(() => ticketNumbersSequence.Dequeue());


            return ticketNumberProviderMock.Object;
        }
    }
}