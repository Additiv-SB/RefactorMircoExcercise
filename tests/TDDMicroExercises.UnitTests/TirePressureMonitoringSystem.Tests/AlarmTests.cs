using Moq;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TDDMicroExercises.UnitTests.TirePressureMonitoringSystem.Tests
{
    public class AlarmTests
    {
        [Test]
        public void Check_PsiPressureValueBelowLowThreshold_AlarmOn_ShouldBeTrue()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(16);

            var alarm = new Alarm(mockSensor.Object);
            alarm.Check();

            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void Check_PsiPressureValueAboveHighThreshold_AlarmOn_ShouldBeTrue()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(22);

            var alarm = new Alarm(mockSensor.Object);
            alarm.Check();

            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestCase(17)]
        [TestCase(21)]
        [TestCase(18)]
        [TestCase(20)]
        public void Check_PsiPressureValueEqualOrBetweenThresholds_AlarmOn_ShouldBeFalse(double psiPressureValue)
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(psiPressureValue);

            var alarm = new Alarm(mockSensor.Object);
            alarm.Check();

            Assert.IsFalse(alarm.AlarmOn);
        }
    }
}
