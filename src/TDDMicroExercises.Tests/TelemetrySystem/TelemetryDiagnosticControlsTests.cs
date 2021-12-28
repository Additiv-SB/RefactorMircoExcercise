using FluentAssertions;
using Moq;
using System;
using TDDMicroExercises.TelemetrySystem;
using TDDMicroExercises.TelemetrySystem.Interfaces;
using Xunit;

namespace TDDMicroExercises.Tests.TelemetrySystem
{
    public class TelemetryDiagnosticControlsTests
    {
        #region tests for unrefactored code
        [Fact]
        public void DiagnosticInfo_WhenObjectCreated_SetToDefaultValue()
        {
            string defaultDiagnosticInfoValue = string.Empty;

            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls();

            telemetryDiagnosticControls.DiagnosticInfo.Should().Be(defaultDiagnosticInfoValue);
        }
        
        [Theory]
        [InlineData("some diagnostic info")]
        [InlineData("another diagnostic info")]
        public void DiagnosticInfo_WhenSetValue_SetToThisValue(string expectedDiagnosticInfoValue)
        {
            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls();
            telemetryDiagnosticControls.DiagnosticInfo = expectedDiagnosticInfoValue;

            telemetryDiagnosticControls.DiagnosticInfo.Should().Be(expectedDiagnosticInfoValue);
        }

        #endregion

        #region tests for refactored code
        [Fact]
        public void CheckTransmission_WhenTelemetryClientConnectionThrowsArgumentNullException_ThrowsArgumentNullException()
        {
            var expectedExceptionMessage = "Value cannot be null.";
            var mockedTelemetryClient = new Mock<ITelemetryClient>();
            mockedTelemetryClient.Setup(x => x.Connect(It.IsAny<string>())).Throws(new ArgumentNullException());

            ITelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockedTelemetryClient.Object);

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(telemetryDiagnosticControls.CheckTransmission);

            exception.Message.Should().Be(expectedExceptionMessage);
        }

        [Fact]
        public void CheckTransmission_WhenTelemetryClientOnlineStatusIsFalse_ThrowsException()
        {
            var expectedExceptionMessage = "Unable to connect.";
            var mockedTelemetryClient = new Mock<ITelemetryClient>();
            mockedTelemetryClient.Setup(x => x.OnlineStatus).Returns(false);
            ITelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockedTelemetryClient.Object);

            Exception exception = Assert.Throws<Exception>(telemetryDiagnosticControls.CheckTransmission);

            exception.Message.Should().Be(expectedExceptionMessage);
        }
        
        [Fact]
        public void CheckTransmission_WhenTelemetryClientSendThrows_ThrowsArgumnetNullException()
        {
            var parameterName = "telemetryServerConnectionString";
            var expectedExceptionMessage = $"Value cannot be null.\r\nParameter name: {parameterName}";
            var mockedTelemetryClient = new Mock<ITelemetryClient>();
            mockedTelemetryClient.Setup(x => x.OnlineStatus).Returns(true);
            mockedTelemetryClient.Setup(x => x.Send(It.IsAny<string>()))
                .Throws(new ArgumentNullException(parameterName));
            ITelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockedTelemetryClient.Object);
            
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(telemetryDiagnosticControls.CheckTransmission);
            
            exception.Message.Should().Be(expectedExceptionMessage);
        }

        [Fact]
        public void CheckTransmission_WhenTelemetryClientReceiveThrows_ThrowsArgumnetNullException()
        {
            var expectedExceptionMessage = "expectedExceptionMessage exception";
            var mockedTelemetryClient = new Mock<ITelemetryClient>();
            mockedTelemetryClient.Setup(x => x.OnlineStatus).Returns(true);
            mockedTelemetryClient.Setup(x => x.Receive())
                .Throws(new Exception(expectedExceptionMessage));
            ITelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockedTelemetryClient.Object);

            Exception exception = Assert.Throws<Exception>(telemetryDiagnosticControls.CheckTransmission);

            exception.Message.Should().Be(expectedExceptionMessage);
        }

        [Fact]
        public void CheckTransmission_WhenTelemetryClientOnlineStatusIsTrueAfterFirstCall_ReturnsExpectedMessage()
        {
            var expectedMessage = "LAST TX rate................ 100 MBPS\r\n"
                    + "HIGHEST TX rate............. 100 MBPS\r\n"
                    + "LAST RX rate................ 100 MBPS\r\n"
                    + "HIGHEST RX rate............. 100 MBPS\r\n"
                    + "BIT RATE.................... 100000000\r\n"
                    + "WORD LEN.................... 16\r\n"
                    + "WORD/FRAME.................. 511\r\n"
                    + "BITS/FRAME.................. 8192\r\n"
                    + "MODULATION TYPE............. PCM/FM\r\n"
                    + "TX Digital Los.............. 0.75\r\n"
                    + "RX Digital Los.............. 0.10\r\n"
                    + "BEP Test.................... -5\r\n"
                    + "Local Rtrn Count............ 00\r\n"
                    + "Remote Rtrn Count........... 00";
            var mockedTelemetryClient = new Mock<ITelemetryClient>();
            mockedTelemetryClient.SetupSequence(x => x.OnlineStatus)
                .Returns(false)
                .Returns(true)
                .Returns(true);

            mockedTelemetryClient.Setup(x => x.Receive()).Returns(expectedMessage);
            ITelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockedTelemetryClient.Object);
            
            telemetryDiagnosticControls.CheckTransmission();

            mockedTelemetryClient.Verify(x => x.Connect(TelemetryDiagnosticConfiguration.DiagnosticChannelConnectionString), Times.Once);
            mockedTelemetryClient.Verify(x => x.Send(TelemetryDiagnosticConfiguration.DiagnosticMessage), Times.Once);
            telemetryDiagnosticControls.DiagnosticInfo.Should().Be(expectedMessage);
        }
        
        [Fact]
        public void CheckTransmission_WhenTelemetryClientOnlineStatusIsTrueAfterSecondCall_ReturnsExpectedMessage()
        {
            var expectedMessage = "LAST TX rate................ 100 MBPS\r\n"
                    + "HIGHEST TX rate............. 100 MBPS\r\n"
                    + "LAST RX rate................ 100 MBPS\r\n"
                    + "HIGHEST RX rate............. 100 MBPS\r\n"
                    + "BIT RATE.................... 100000000\r\n"
                    + "WORD LEN.................... 16\r\n"
                    + "WORD/FRAME.................. 511\r\n"
                    + "BITS/FRAME.................. 8192\r\n"
                    + "MODULATION TYPE............. PCM/FM\r\n"
                    + "TX Digital Los.............. 0.75\r\n"
                    + "RX Digital Los.............. 0.10\r\n"
                    + "BEP Test.................... -5\r\n"
                    + "Local Rtrn Count............ 00\r\n"
                    + "Remote Rtrn Count........... 00";
            var mockedTelemetryClient = new Mock<ITelemetryClient>();
            mockedTelemetryClient.SetupSequence(x => x.OnlineStatus)
                .Returns(false)
                .Returns(false)
                .Returns(true)
                .Returns(true);

            mockedTelemetryClient.Setup(x => x.Receive()).Returns(expectedMessage);
            ITelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockedTelemetryClient.Object);
            
            telemetryDiagnosticControls.CheckTransmission();

            mockedTelemetryClient.Verify(x => x.Connect(TelemetryDiagnosticConfiguration.DiagnosticChannelConnectionString), Times.Exactly(2));
            mockedTelemetryClient.Verify(x => x.Send(TelemetryDiagnosticConfiguration.DiagnosticMessage), Times.Once);
            telemetryDiagnosticControls.DiagnosticInfo.Should().Be(expectedMessage);
        }
        
        [Fact]
        public void CheckTransmission_WhenTelemetryClientOnlineStatusIsTrueAfterThirdCall_ReturnsExpectedMessage()
        {
            var expectedMessage = "LAST TX rate................ 100 MBPS\r\n"
                    + "HIGHEST TX rate............. 100 MBPS\r\n"
                    + "LAST RX rate................ 100 MBPS\r\n"
                    + "HIGHEST RX rate............. 100 MBPS\r\n"
                    + "BIT RATE.................... 100000000\r\n"
                    + "WORD LEN.................... 16\r\n"
                    + "WORD/FRAME.................. 511\r\n"
                    + "BITS/FRAME.................. 8192\r\n"
                    + "MODULATION TYPE............. PCM/FM\r\n"
                    + "TX Digital Los.............. 0.75\r\n"
                    + "RX Digital Los.............. 0.10\r\n"
                    + "BEP Test.................... -5\r\n"
                    + "Local Rtrn Count............ 00\r\n"
                    + "Remote Rtrn Count........... 00";
            var mockedTelemetryClient = new Mock<ITelemetryClient>();
            mockedTelemetryClient.SetupSequence(x => x.OnlineStatus)
                .Returns(false)
                .Returns(false)
                .Returns(false)
                .Returns(true)
                .Returns(true);

            mockedTelemetryClient.Setup(x => x.Receive()).Returns(expectedMessage);
            ITelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockedTelemetryClient.Object);
            
            telemetryDiagnosticControls.CheckTransmission();

            mockedTelemetryClient.Verify(x => x.Connect(TelemetryDiagnosticConfiguration.DiagnosticChannelConnectionString), Times.Exactly(3));
            mockedTelemetryClient.Verify(x => x.Send(TelemetryDiagnosticConfiguration.DiagnosticMessage), Times.Once);
            telemetryDiagnosticControls.DiagnosticInfo.Should().Be(expectedMessage);
        }
        #endregion
    }
}
