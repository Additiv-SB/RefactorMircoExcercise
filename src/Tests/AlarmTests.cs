using Moq;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace Tests
{
    [TestFixture]
    public class AlarmTests
    {
        private readonly Mock<ISensor> _mockSensor = new Mock<ISensor>();

        [Test]
        public void AlarmOn_DefaultValue_ShouldBeFalse()
        {
            var alarm = new Alarm();
            Assert.IsFalse(alarm.AlarmOn);
        }

        [Test]
        [TestCase(5, 10, 1, true, AlarmOnShouldBeTrueIfSensorValueLessThenMinValueMsg)]
        [TestCase(5, 10, 5, false, AlarmOnShouldBeFalseMsg)]
        [TestCase(5, 10, 7, false, AlarmOnShouldBeFalseMsg)]
        [TestCase(5, 10, 10, false, AlarmOnShouldBeFalseMsg)]
        [TestCase(5, 10, 11, true, AlarmOnShouldBeTrueIfSensorValueMoreThenMaxValueMsg)]

        public void Check_ExpectedValue(double minVal, double maxVal, double sensorValue, bool expectedResult, string errorMessage)
        {
            _mockSensor
                .Setup(sensor => sensor.PopNextPressurePsiValue())
                .Returns(sensorValue);

            var alarm = new Alarm(_mockSensor.Object, new AlarmConfiguration
            {
                LowPressureThreshold  = minVal,
                HighPressureThreshold = maxVal
            });
            
            alarm.Check();
            
            Assert.AreEqual(expectedResult,alarm.AlarmOn, errorMessage);
        }

        #region ErrorMessage constants
        
        private const string AlarmOnShouldBeTrueIfSensorValueLessThenMinValueMsg =
            "AlarmOn should be true if sensor pressure psi value less then Low Pressure Threshold value";
        private const string AlarmOnShouldBeFalseMsg =
            "AlarmOn should be false if sensor pressure psi value >= LowPressureThreshold and <= HighPressureThreshold";
        private const string AlarmOnShouldBeTrueIfSensorValueMoreThenMaxValueMsg =
            "AlarmOn should be true if sensor pressure psi value more then Max Pressure Threshold value";

        #endregion
    }
}