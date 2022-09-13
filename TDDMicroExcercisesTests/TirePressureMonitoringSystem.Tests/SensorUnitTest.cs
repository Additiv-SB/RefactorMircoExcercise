using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem.Abstractions;
using Xunit;

namespace TDDMicroExcercisesTests.TirePressureMonitoringSystem.Tests
{
    public class SensorUnitTest
    {

        [Fact]
        public void CheckReadPressureSample_ShouldBeTrueOnSameValue()
        {
            // Arrange
            Mock<ISensor> sensorMock = new Mock<ISensor>();
            sensorMock.Setup(x => x.PopNextPressurePsiValue()).Returns(6);

            Assert.Equal(6, sensorMock.Object.PopNextPressurePsiValue());
        }

        [Fact]
        public void PopNextPressurePsiValue_ShouldBeTrueOMocked()
        {
            // Arrange
            Mock<ISensor> sensorMock = new Mock<ISensor>();
            sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(25);

            Assert.Equal(25, sensorMock.Object.PopNextPressurePsiValue());
        }
    }
}
