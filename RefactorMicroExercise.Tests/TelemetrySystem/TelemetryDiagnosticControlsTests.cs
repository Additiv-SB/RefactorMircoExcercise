using Xunit;
using TDDMicroExercises.TelemetrySystem;
using Moq;
using System;

namespace RefactorMicroExercise.Tests.UnicodeFileToHtmlTextConverterTests
{
    public class TelemetryDiagnosticControlsTests
    {
        //test before refactor
        [Fact]
        public void DiagnosticInfo_SetToDefault_WhenCreated()
        {
            string defaultValue = string.Empty;

            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls();

            Assert.Equal(defaultValue, telemetryDiagnosticControls.DiagnosticInfo);
        }

        [Fact]
        public void CheckTransmission_UnableToConnect_ShouldThrowException()
        {
            // Arrange
            string expectedMessage = "Unable to connect.";
            Mock<ITelemetryClient> mockTelemetryClient = new Mock<ITelemetryClient>();
            mockTelemetryClient.Setup(x => x.Disconnect()).Throws(new Exception(expectedMessage));
            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockTelemetryClient.Object);
            
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
            mockTelemetryClient.Setup(x => x.Connect(It.IsAny<string>()));
            mockTelemetryClient.Setup(x => x.OnlineStatus).Returns(true);

            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockTelemetryClient.Object);

            // Act
            telemetryDiagnosticControls.CheckTransmission();

            // Assert
            Assert.NotEqual(string.Empty, telemetryDiagnosticControls.DiagnosticInfo);
        }

    }
}
