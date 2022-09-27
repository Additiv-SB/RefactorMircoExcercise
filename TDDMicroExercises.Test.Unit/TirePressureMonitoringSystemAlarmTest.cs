using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TDDMicroExercises.Test.Unit
{
    [TestClass]
    public class TirePressureMonitoringSystemAlarmTest
    {
        private readonly Mock<ISensor> _sensor = new(MockBehavior.Strict);

        /// <summary>
        /// Test method for normal pressure value. Alarm should not be raise.
        /// </summary>
        [TestMethod]
        public void NormalPressureValueNotRaiseAlarm()
        {
            //Arrange
            var alarm = new Alarm(_sensor.Object);
           _sensor.Setup(s => s.PopNextPressurePsiValue()).Returns(18.0);

            //Act
            alarm.Check();

            ////Assert
            Assert.IsFalse(alarm.AlarmOn);
        }

        /// <summary>
        /// Test method for low pressure value. Alarm should be raised.
        /// </summary>
        [TestMethod]
        public void LowPressureValueShouldRaiseAlarm()
        {
            //Arrange
            var alarm = new Alarm(_sensor.Object);
            _sensor.Setup(s => s.PopNextPressurePsiValue()).Returns(12.5532);

            //Act
            alarm.Check();

            //Assert
            Assert.IsTrue(alarm.AlarmOn);
        }

        /// <summary>
        /// Test method for high pressure value. Alarm should be raised.
        /// </summary>
        [TestMethod]
        public void HighPressureValueShouldRaiseAlarm()
        {
            //Arrange
            var alarm = new Alarm(_sensor.Object);
            _sensor.Setup(s => s.PopNextPressurePsiValue()).Returns(22.2321);

            //Act
            alarm.Check();

            //Assert
            Assert.IsTrue(alarm.AlarmOn);
        }
    }
}