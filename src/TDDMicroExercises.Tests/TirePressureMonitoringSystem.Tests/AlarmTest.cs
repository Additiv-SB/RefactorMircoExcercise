using FluentAssertions;
using NSubstitute;
using TDDMicroExercises.TirePressureMonitoringSystem;
using Xunit;

namespace TDDMicroExercises.Tests.TirePressureMonitoringSystem.Tests
{
    public sealed class AlarmTest
    {
        [Theory]
        [InlineData(21.1)]
        public void Check_should_verify_pressure_value_above_high_pressure_and_set_alarme_on(double pressureValue)
        {
            // Arrange
            ISensor sensor = Substitute.For<ISensor>();
            IAlarm alarme = new Alarm(sensor);

            sensor.PopNextPressurePsiValue().Returns(pressureValue);

            // Act
            alarme.Check();

            // Assert
            alarme.AlarmOn.Should().Be(true);
        }

        [Theory]
        [InlineData(16.9)]
        public void Check_should_verify_pressure_value_below_low_pressure_and_set_alarme_on(double pressureValue)
        {
            // Arrange
            ISensor sensor = Substitute.For<ISensor>();
            IAlarm alarme = new Alarm(sensor);

            sensor.PopNextPressurePsiValue().Returns(pressureValue);

            // Act
            alarme.Check();

            // Assert
            alarme.AlarmOn.Should().Be(true);
        }

        [Theory]
        [InlineData(17)]
        [InlineData(17.1)]
        [InlineData(20.9)]
        [InlineData(21)]
        public void Check_should_verify_pressure_value_is_normal_and_set_alarme_off(double pressureValue)
        {
            // Arrange
            ISensor sensor = Substitute.For<ISensor>();
            IAlarm alarme = new Alarm(sensor);

            sensor.PopNextPressurePsiValue().Returns(pressureValue);

            // Act
            alarme.Check();

            // Assert
            alarme.AlarmOn.Should().Be(false);
        }
    }
}
