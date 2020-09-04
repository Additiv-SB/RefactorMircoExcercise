using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem;
using Xunit;

namespace TDDMicroExercises.Tests.TirePressureMonitoringSystem
{
    public class AlarmTests : AppTestBase
    {
        [Fact]
        public void Alarm_Success_Obsolete_Ctor()
        {
            var alarm = new Alarm();
            alarm.Check();
        }

        [Fact]
        public void Alarm_Success()
        {
            var target = ServiceCollection
                .BuildServiceProvider()
                .GetService<IAlarm>();

            target.Check();
        }

        [Fact]
        public void Alarm_ShouldBeOn_When_Pressure_Lesser_Than_LowPressureThreshold()
        {
            MockSensor(16.99999999999999);

            var target = ServiceCollection
                .BuildServiceProvider()
                .GetService<IAlarm>();

            target.Check();
            target.AlarmOn.Should().BeTrue();
        }

        [Fact]
        public void Alarm_ShouldBeOn_When_Pressure_Greater_Than_HighPressureThreshold()
        {
            //Mocking Sensor to return value grater than HighPressureThreshold
            MockSensor(21.00000000000001);

            var target = ServiceCollection
                .BuildServiceProvider()
                .GetService<IAlarm>();

            target.Check();
            target.AlarmOn.Should().BeTrue();
        }

        [Fact]
        public void Alarm_ShouldBeOff_When_Pressure_Lower_Than_LowPressureThreshold()
        {
            MockSensor(20.999999999999999);

            var target = ServiceCollection
                .BuildServiceProvider()
                .GetService<IAlarm>();

            target.Check();
            target.AlarmOn.Should().BeFalse();
        }

        private void MockSensor(double psiPressureValue)
        {
            var sensorMock = new Mock<ISensor>();

            sensorMock
                .Setup(s => s.PopNextPressurePsiValue())
                .Returns(psiPressureValue);

            //Overriding ISensor implementation with mocked instance
            ServiceCollection
                .AddTransient((x) => sensorMock.Object);
        }
    }
}
