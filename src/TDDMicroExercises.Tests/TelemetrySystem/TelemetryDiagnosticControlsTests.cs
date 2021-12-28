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
            var expectedExcMessage = "expected message";
            var mockedTelemetryClient = new Mock<ITelemetryClient>();
            mockedTelemetryClient.Setup(x => x.Connect(It.IsAny<string>())).Throws(new ArgumentNullException(expectedExcMessage));
            
            TelemetryDiagnosticControls telemetryDiagnosticControls = new TelemetryDiagnosticControls(mockedTelemetryClient.Object);
            
            try
            {
                telemetryDiagnosticControls.CheckTransmission();
                Assert.NotNull("Exception should be thrown");
            }
            catch(ArgumentNullException ex)
            {
                telemetryDiagnosticControls;
            }


        }

        #endregion
    }
}
