using FluentAssertions;
using TDDMicroExercises.TirePressureMonitoringSystem;
using Xunit;

namespace TDDMicroExercises.Tests.TirePressureMonitoringSystem.Tests
{
    public sealed class AlarmTest
    {
        [Fact]
        public void Check_should_verify_pressure_value_and_set_alarme_on()
        {
            // Arrange
            Alarm alarme = new();

            // Act
            alarme.Check();

            // Assert
            alarme.AlarmOn.Should().Be(true);
        }
    }
}
