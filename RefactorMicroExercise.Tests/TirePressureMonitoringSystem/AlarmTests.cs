using TDDMicroExercises.TirePressureMonitoringSystem;
using Xunit;
using Moq;

namespace RefactorMicroExercise.Tests.TirePressureMonitoringSystem
{
    public class AlarmTests
    {
        //test before refactor
        [Fact]
        public void AlarmOn_ShouldReturnFalseByDefault()
        {
            bool defaultValue = false;

            Alarm alarm = new Alarm();

            Assert.Equal(defaultValue, alarm.AlarmOn);
        }

        [Theory]
        [InlineData(17, false)]
        [InlineData(16, true)]
        [InlineData(22, true)]
        [InlineData(21.01, true)]
        [InlineData(17.01, false)]
        public void Check_WhenSensorPoppedValidValu_ReturnsExpected(double sensorValue, bool expectedResult)
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
    }
}
