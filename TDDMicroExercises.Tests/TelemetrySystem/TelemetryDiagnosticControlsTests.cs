using FluentAssertions;
using TDDMicroExercises.TelemetrySystem;
using Xunit;

namespace TDDMicroExercises.Tests.TelemetrySystem
{
    public class TelemetryDiagnosticControlsTests
    {
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
    }
}
