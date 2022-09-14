using Moq;
using TDDMicroExercises.TelemetrySystem.Abstractions;
using TDDMicroExercises.TelemetrySystem.Constants;
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

        [Fact]
        public void DiagnosticInfo_NotEmpty_WhenOnlineIsTrue()
        {
            // Arrange
            Mock<ITelemetryClient> mockTelemetryClient = new Mock<ITelemetryClient>();
            Mock<ITelemetryTransmitter> mockTelemetryTransmitter = new Mock<ITelemetryTransmitter>();
            mockTelemetryClient.Setup(x => x.Connect(It.IsAny<string>()));
            mockTelemetryClient.Setup(x => x.OnlineStatus).Returns(true);
            mockTelemetryTransmitter.Setup(x => x.Send(It.IsAny<string>()));
            mockTelemetryTransmitter.Setup(x => x.Receive()).Returns(TelemetrySystemConstants.DiagnosticMessage);

            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockTelemetryClient.Object, mockTelemetryTransmitter.Object);

            // Act
            telemetryDiagnosticControls.CheckTransmission();

            // Assert
            Assert.NotEqual(string.Empty, telemetryDiagnosticControls.DiagnosticInfo);
            Assert.Equal(telemetryDiagnosticControls.DiagnosticInfo, TelemetrySystemConstants.DiagnosticMessage);
        }
    }
}
