using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem;
using Xunit;

namespace RefactorExcerciseTests.TirePressureUnitTests
{
    public class SensorUnitTests
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
            sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(22);

            Assert.Equal(22, sensorMock.Object.PopNextPressurePsiValue());
        }
    }
}