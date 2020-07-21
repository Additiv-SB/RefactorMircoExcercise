using Moq;
using NUnit.Framework;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
    [TestFixture]
    public class AlarmTest
    {
        [Test]
        public void CheckBelowLowThresholdTest()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(10);

            var alarm = new Alarm(mockSensor.Object);
            alarm.Check();

            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void CheckAboveHighThresholdTest()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(25);

            var alarm = new Alarm(mockSensor.Object);
            alarm.Check();

            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void CheckEqualOrBetweenThresholdsTest()
        {
            var mockSensor = new Mock<ISensor>();
            Alarm alarm;

            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(17);
            alarm = new Alarm(mockSensor.Object);
            alarm.Check();

            Assert.IsFalse(alarm.AlarmOn);            

            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(21);
            alarm = new Alarm(mockSensor.Object);
            alarm.Check();

            Assert.IsFalse(alarm.AlarmOn);

            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(19);
            alarm = new Alarm(mockSensor.Object);
            alarm.Check();

            Assert.IsFalse(alarm.AlarmOn);
        }
    }
}
