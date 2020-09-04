using System;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TDDMicroExercises.TelemetrySystem;
using Xunit;

namespace TDDMicroExercises.Tests.TelemetrySystem
{
    public class TelemetryDiagnosticControlsTests : AppTestBase
    {
        //To be removed once external dependencies stop using default ctor
        [Fact]
        public void Success_Obsolete_Ctor()
        {
            try
            {
                var target = new TelemetryDiagnosticControls();
                target.CheckTransmission();
            }
            catch (Exception e)
            {
                //Without mocking TelemetryClient it is possible that exception will be thrown
                if (e.Message != "Unable to connect.")
                {
                    throw;
                }
            }
        }

        [Fact]
        public void Unable_to_connect_should_throw_exception()
        {
            var telemetryClientMock = new Mock<ITelemetryClient>();

            //Mocking telemetry client to ensure it will be in connected state
            telemetryClientMock
                .Setup(x => x.Connect(It.IsAny<string>()))
                .Verifiable();

            telemetryClientMock
                .SetupGet(x => x.OnlineStatus)
                .Returns(false);

            ServiceCollection.AddTransient((x) => telemetryClientMock.Object);

            var target = ServiceCollection
                .BuildServiceProvider()
                .GetService<ITelemetryDiagnosticControls>();

            //Using xUnit Assert, because FluentAssertions must be extended to support void method exception assertion
            var ex = Assert.Throws<Exception>(() => target.CheckTransmission());
            ex.Message
                .Should()
                .Be("Unable to connect.");
        }

        [Fact]
        public void DiagnosticInfo_should_not_be_empty()
        {
            var telemetryClientMock = new Mock<ITelemetryClient>();

            //Mocking telemetry client to ensure it will be in connected state
            telemetryClientMock
                .Setup(x => x.Connect(It.IsAny<string>()))
                .Verifiable();

            telemetryClientMock
                .SetupGet(x => x.OnlineStatus)
                .Returns(true);

            ServiceCollection.AddTransient((x) => telemetryClientMock.Object);

            var target = ServiceCollection
                .BuildServiceProvider()
                .GetService<ITelemetryDiagnosticControls>();

            target.CheckTransmission();

            target.DiagnosticInfo
                .Should()
                .NotBeEmpty();
        }
    }
}
