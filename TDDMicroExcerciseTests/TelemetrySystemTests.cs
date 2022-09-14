using Moq;
using TDDMicroExercises.TelemetrySystem.Abstractions;
using TDDMicroExercises.TelemetrySystem.Implementations;

namespace TDDMicroExcerciseTests
{
    public class TelemetrySystemTests
    {
        [Fact]
        public void CheckTransmission_UnableToConnect_ShouldThrowException()
        {
            // Arrange
            string expectedMessage = "Unable to connect.";
            Mock<ITelemetryClient> mockTelemetryClient = new Mock<ITelemetryClient>();
            Mock<ITelemetryTransmitter> mockTelemetryTransmitter = new Mock<ITelemetryTransmitter>();
            mockTelemetryClient.Setup(x => x.Disconnect()).Throws(new Exception(expectedMessage));
            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockTelemetryClient.Object, mockTelemetryTransmitter.Object);

            // Act
            var exception = Assert.Throws<Exception>(() => telemetryDiagnosticControls.CheckTransmission());

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
