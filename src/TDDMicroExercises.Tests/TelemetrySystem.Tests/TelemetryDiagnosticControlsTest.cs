using FluentAssertions;
using TDDMicroExercises.TelemetrySystem;
using Xunit;

namespace TDDMicroExercises.Tests.TelemetrySystem.Tests
{
    public sealed class TelemetryDiagnosticControlsTest
    {
        [Fact]
        public void CheckTransmission_should_send_a_diagnostic_message_and_receive_a_status_message_response()
        {
            // Arrange
            TelemetryDiagnosticControls tdc = new();

            // Act
            Action act = () => tdc.CheckTransmission();

            // Assert
            act.Should().NotThrow();

            tdc.DiagnosticInfo.Should().NotBe(string.Empty);
        }
    }
}
