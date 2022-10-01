using FluentAssertions;
using NSubstitute;
using TDDMicroExercises.TelemetrySystem;
using Xunit;

namespace TDDMicroExercises.Tests.TelemetrySystem.Tests
{
    public sealed class TelemetryDiagnosticControlsTest
    {
        [Fact]
        public void CheckTransmission_should_send_a_diagnostic_message_and_receive_a_status_message_response()
        {
            string status_message_response = "This is the response message";

            // Arrange
            ITelemetryClient _telemetryClient = Substitute.For<ITelemetryClient>();
            ITelemetryDiagnosticControls tdc = new TelemetryDiagnosticControls(_telemetryClient);

            _telemetryClient.OnlineStatus.Returns(false);
            _telemetryClient.When(call => call.Connect(Arg.Any<string>())).Do(arg => _telemetryClient.OnlineStatus.Returns(true));
            _telemetryClient.Receive().Returns(status_message_response);

            // Act
            tdc.CheckTransmission();

            // Assert
            tdc.DiagnosticInfo.Should().Be(status_message_response);

            _telemetryClient.Received(2).Disconnect();

            _telemetryClient.Received(1).Connect(Arg.Any<string>());

            _telemetryClient.Received(1).Send(Arg.Any<string>());

            _telemetryClient.Received(1).Receive();
        }

        [Fact]
        public void CheckTransmission_fail_3_times_to_connect()
        {
            // Arrange
            ITelemetryClient _telemetryClient = Substitute.For<ITelemetryClient>();
            ITelemetryDiagnosticControls tdc = new TelemetryDiagnosticControls(_telemetryClient);

            _telemetryClient.OnlineStatus.Returns(false);

            // Act
            Action act = () => tdc.CheckTransmission();

            // Assert
            act.Should().Throw<Exception>().WithMessage("Unable to connect.");

            _telemetryClient.Received(2).Disconnect();

            _telemetryClient.Received(3).Connect(Arg.Any<string>());

            _telemetryClient.DidNotReceive().Send(Arg.Any<string>());

            _telemetryClient.DidNotReceive().Receive();
        }
    }
}
