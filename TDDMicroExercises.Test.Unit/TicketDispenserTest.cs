using System.ComponentModel;
using TDDMicroExercises.TurnTicketDispenser;

namespace TDDMicroExercises.Test.Unit
{
    [TestClass]
    public class TicketDispenserTest
    {

        /// <summary>
        /// The new generated ticket shout have a TurnNumber greater that the previous one
        /// </summary>
        [TestMethod]
        public void NewTicketReturnTurnNumberGreaterThanPreviousTicket()
        {
            //Arrange
            var ticketDispenser = new TicketDispenser();

            //Act
            for (int i = 0; i < 5; i++)
            {
                var previousTicket = ticketDispenser.GetTurnTicket();
                var nextTicket = ticketDispenser.GetTurnTicket();

                //Assert
                Assert.IsTrue(nextTicket.TurnNumber > previousTicket.TurnNumber);
            }
        }

        /// <summary>
        /// The new generated ticket from two different ticket dispensers should have a greater TurnNumber than the previous one
        /// </summary>
        [TestMethod]
        public void NewTicketTurnNumberFromOtherDispenserGreaterThanThePreviousTicketFromAnotherDispenser()
        {
            //Arrange
            var firstDispenser = new TicketDispenser();
            var secondDispenser = new TicketDispenser();

            //Act
            for (int i = 0; i < 5; i++)
            {
                var previousTicket = firstDispenser.GetTurnTicket();
                var newTicket = secondDispenser.GetTurnTicket();

                //Assert
                Assert.IsTrue(newTicket.TurnNumber > previousTicket.TurnNumber);
            }
           
        }
    }
}
