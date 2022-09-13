using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem.Abstractions;
using TDDMicroExercises.TirePressureMonitoringSystem.Implementations;
using Xunit;

namespace TDDMicroExcercisesTests.TirePressureMonitoringSystem.Tests
{
    public class AlarmUnitTests
    {

        [Theory]
        [InlineData(0, true)]
        [InlineData(0.99, true)]
        [InlineData(8, true)]
        [InlineData(16, true)]
        [InlineData(22, true)]

        public void CheckDifferentSensorValues_ShouldBeTrue(double sensorValue, bool expectedResult)
        {
            // Arrange
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(sensorValue);


            Alarm alarm = new Alarm(mockSensor.Object);

            // Act
            alarm.Check();

            // Assert
            Assert.Equal(expectedResult, alarm.AlarmOn);
        }

        [Theory]
        [InlineData(17, false)]
        [InlineData(17.1, false)]
        [InlineData(20.99, false)]
        [InlineData(21, false)]
        [InlineData(19, false)]
        public void CheckDifferentSensorValues_ShouldBeFalse(double sensorValue, bool expectedResult)
        {
            // Arrange
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(sensorValue);


            Alarm alarm = new Alarm(mockSensor.Object);

            // Act
            alarm.Check();

            // Assert
            Assert.Equal(expectedResult, alarm.AlarmOn);
        }

        [Fact]
        public void Alarm_ShouldBeFalseByDefault()
        {
            Alarm alarm = new Alarm(new Sensor());

            Assert.False(alarm.AlarmOn);
        }
    }
}
