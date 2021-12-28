using System;
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
        [TestCase(5, 10, 5)]
        [TestCase(5, 10, 7)]
        [TestCase(5, 10, 10)]
        public void Check_WithValueInValidRange_ShouldBeAlarmOnFalse(double minVal, double maxVal, double sensorValue)
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
            
            Assert.IsFalse(alarm.AlarmOn);
        }
        
        [Test]
        [TestCase(5, 10, 1)]
        [TestCase(5, 10, 11)]
        public void Check_WithValueOutOfValidRange_ShouldBeAlarmOnTrue(double minVal, double maxVal, double sensorValue)
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
            
            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void Check_SensorException()
        {
            var exception = new Exception("Sensor exception");
            
            _mockSensor
                .Setup(sensor => sensor.PopNextPressurePsiValue())
                .Throws(exception);

            var alarm = new Alarm(_mockSensor.Object, new AlarmConfiguration());

            try
            {
                alarm.Check();
            }
            catch (Exception ex)
            {
                Assert.AreSame(exception, ex);
            }
        }
    }
}