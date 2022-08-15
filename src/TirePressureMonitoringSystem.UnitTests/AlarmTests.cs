using Moq;
using Xunit;
using Xunit.Abstractions;

namespace TDDMicroExercises.TirePressureMonitoringSystem.UnitTests
{
    public class AlarmTests
    {
        private readonly ITestOutputHelper _logger;

        public AlarmTests(ITestOutputHelper logger)
        {
            _logger = logger;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.99)]
        [InlineData(6)]
        public void Check_AlarmOn(double value)
        {
            var sensorMock = new Mock<Sensor>();
            sensorMock.Setup(s => s.ReadPressureSample()).Returns(value);

            var alarm = new Alarm(sensorMock.Object);
            
            alarm.Check();
            
            Assert.True(alarm.AlarmOn);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Check_AlarmOff(double value)
        {
            var sensorMock = new Mock<Sensor>();
            sensorMock.Setup(s => s.ReadPressureSample()).Returns(value);

            var alarm = new Alarm(sensorMock.Object);
            
            alarm.Check();
            
            Assert.False(alarm.AlarmOn);
        }
    }
}