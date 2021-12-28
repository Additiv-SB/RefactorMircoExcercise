using FluentAssertions;
using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;
using Xunit;

namespace TDDMicroExercises.Tests.TirePressureMonitoringSystem
{
    public class AlarmTests
    {
        #region tests for unmodified code 
        [Fact]
        public void AlarmOn_WhenAlarmObjectCreated_SetToDefault()
        {
            bool defaultAlarmOnValue = false;
            
            Alarm alarm = new Alarm();
            
            alarm.AlarmOn.Should().Be(defaultAlarmOnValue);
        }
        #endregion

        #region tests for refactored code
        [Theory]
        [InlineData(PressureConfiguration.LowPressureThreshold)]
        [InlineData(PressureConfiguration.HighPressureThreshold)]
        [InlineData(PressureConfiguration.LowPressureThreshold + 1)]
        [InlineData(PressureConfiguration.HighPressureThreshold - 1)]
        public void Check_WhenSensorPoppedValue_AlarmIsOff(double poppedValue)
        {
            Mock<ISensor> mockedSensor = new Mock<ISensor>();
            mockedSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(poppedValue);
            bool expectedAlarmOnValue = false;

            IAlarm alarm = new Alarm(mockedSensor.Object);
            alarm.Check();

            mockedSensor.Verify(x => x.PopNextPressurePsiValue(), Times.Once);
            alarm.AlarmOn.Should().Be(expectedAlarmOnValue);
        }
        
        [Theory]
        [InlineData(PressureConfiguration.LowPressureThreshold - 1)]
        [InlineData(PressureConfiguration.HighPressureThreshold + 1)]

        public void Check_WhenSensorPoppedInvalidValue_AlarmIsOn(double poppedValue)
        {
            Mock<ISensor> mockedSensor = new Mock<ISensor>();
            mockedSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(poppedValue);
            bool expectedAlarmOnValue = true;

            IAlarm alarm = new Alarm(mockedSensor.Object);
            alarm.Check();

            mockedSensor.Verify(x => x.PopNextPressurePsiValue(), Times.Once);
            alarm.AlarmOn.Should().Be(expectedAlarmOnValue);
        }

        #endregion
    }

}

