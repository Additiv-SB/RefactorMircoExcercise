using Xunit;
using TDDMicroExercises.TelemetrySystem;
using Moq;
using System;
using System.Threading.Tasks;

namespace RefactorMicroExercise.Tests.UnicodeFileToHtmlTextConverterTests
{
    public class TelemetryDiagnosticControlsUnitTests
    {

        [Fact]
        public void DiagnosticInfoAfterCreating_ShouldHasDefaultValue()
        {
            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls();

            Assert.Equal(string.Empty, telemetryDiagnosticControls.DiagnosticInfo);
        }

        [Fact]
        public void DiagnosticInfoWhenOnlineIsTrue_ShouldReturnEmpty()
        {
            // Arrange
            Mock<ITelemetryClient> telemetryClientMock = new Mock<ITelemetryClient>();
            telemetryClientMock.Setup(x => x.Connect(It.IsAny<string>()));
            telemetryClientMock.Setup(x => x.OnlineStatus).Returns(true);

            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(telemetryClientMock.Object);

            // Act
            telemetryDiagnosticControls.CheckTransmission();

            // Assert
            Assert.NotEqual(string.Empty, telemetryDiagnosticControls.DiagnosticInfo);
        }
        [Fact]
        public void Exception_ShouldBeThrown_IfNullPassedToConnectFunction()
        {
            string message = "Unable to connect.";
            // Arrange
            Mock<ITelemetryClient> telemetryClientMock = new Mock<ITelemetryClient>();
            telemetryClientMock.Setup(x => x.Connect(null)).Throws(new Exception(message)) ;
            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(telemetryClientMock.Object);

            // Act
            var exception = Assert.Throws<Exception>(() => telemetryDiagnosticControls.CheckTransmission());

            // Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void CheckTransmission_ShouldThrowException()
        {
            // Arrange
            string message = "Unable to connect.";
            Mock<ITelemetryClient> telemetryClientMock = new Mock<ITelemetryClient>();
            telemetryClientMock.Setup(x => x.Disconnect()).Throws(new Exception(message));
            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(telemetryClientMock.Object);

            // Act
            var exception = Assert.Throws<Exception>(() => telemetryDiagnosticControls.CheckTransmission());

            // Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void DiagnosticInfo_NotEmpty_WhenOnlineIsTrue()
        {
            // Arrange
            Mock<ITelemetryClient> telemetryClientMock = new Mock<ITelemetryClient>();
            telemetryClientMock.Setup(x => x.Connect(It.IsAny<string>()));
            telemetryClientMock.Setup(x => x.OnlineStatus).Returns(true);

            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(telemetryClientMock.Object);

            // Act
            telemetryDiagnosticControls.CheckTransmission();

            // Assert
            Assert.NotEqual(string.Empty, telemetryDiagnosticControls.DiagnosticInfo);
        }


        [Fact]
        public void DiagnosticInfo_Empty_WhenOnlineIsFalse()
        {
            // Arrange
            string message = "Unable to connect.";
            Mock<ITelemetryClient> telemetryClientMock = new Mock<ITelemetryClient>();
            telemetryClientMock.Setup(x => x.Connect(It.IsAny<string>()));
            telemetryClientMock.Setup(x => x.OnlineStatus).Returns(false);

            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(telemetryClientMock.Object);

            // Act
            telemetryDiagnosticControls.CheckTransmission();

            // Assert
            Assert.NotEqual(message, telemetryDiagnosticControls.DiagnosticInfo);
        }

    }
}
