using Moq;
using NUnit.Framework;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Test
{
    //Testing the Alarm class using mock implementation of Sensor
    [TestFixture]
    public class AlarmTest
    {
        [Test]
        public void Check_WhetherAlarmOnWhenPressureBelowLowThreshold()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(sensor => sensor.PopNextPressurePsiValue()).Returns(15); 
            var alarm = new Alarm(mockSensor.Object);

            alarm.Check();

            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void Check_WhetherAlarmOnWhenPressureAboveHighThreshold()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(sensor => sensor.PopNextPressurePsiValue()).Returns(22); 
            var alarm = new Alarm(mockSensor.Object);

            alarm.Check();

            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void Check_WhetherAlarmOffWhenPressureWithinThresholdRange()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(sensor => sensor.PopNextPressurePsiValue()).Returns(18);
            var alarm = new Alarm(mockSensor.Object);

            alarm.Check();

            Assert.IsFalse(alarm.AlarmOn);
        }
    }
}
