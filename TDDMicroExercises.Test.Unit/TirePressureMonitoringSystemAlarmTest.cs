using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TDDMicroExercises.Test.Unit
{
    [TestClass]
    public class TirePressureMonitoringSystemAlarmTest
    {
        private readonly Mock<ISensor> _sensor = new(MockBehavior.Strict);

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

        [TestMethod]
        public void LowPressureValueShouldRaiseAlarm()
        {
            //Arrange
            var alarm = new Alarm(_sensor.Object);
            _sensor.Setup(s => s.PopNextPressurePsiValue()).Returns(12.0);

            //Act
            alarm.Check();

            //Assert
            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void HighPressureValueShouldRaiseAlarm()
        {
            //Arrange
            var alarm = new Alarm(_sensor.Object);
            _sensor.Setup(s => s.PopNextPressurePsiValue()).Returns(22);

            //Act
            alarm.Check();

            //Assert
            Assert.IsTrue(alarm.AlarmOn);
        }
    }
}