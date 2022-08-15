using System.Runtime.CompilerServices;
using Moq;
using Xunit;
using Xunit.Abstractions;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace TDDMicroExercises.TirePressureMonitoringSystem.UnitTests
{
    public class SensorTests
    {
        private readonly ITestOutputHelper _logger;

        public SensorTests(ITestOutputHelper logger)
        {
            _logger = logger;
        }

        [Fact]
        public void ReadPressureSample_MockedValue()
        {
            var sensorMock = new Mock<Sensor>();
            sensorMock.Setup(s => s.ReadPressureSample()).Returns(6);
            
            Assert.Equal(6, sensorMock.Object.ReadPressureSample());
        }

        [Fact]
        public void PopNextPressurePsiValue_LowPressureMocked()
        {
            var sensorMock = new Mock<Sensor>();
            sensorMock.Setup(s => s.ReadPressureSample()).Returns(0);
            
            Assert.Equal(16, sensorMock.Object.PopNextPressurePsiValue());
        }
        
        [Fact]
        public void PopNextPressurePsiValue_HighPressureMocked()
        {
            var sensorMock = new Mock<Sensor>();
            sensorMock.Setup(s => s.ReadPressureSample()).Returns(6);
            
            Assert.Equal(22, sensorMock.Object.PopNextPressurePsiValue());
        }
        
        [Fact]
        public void PopNextPressurePsiValue_AlwaysInRange_16_22()
        {
            var sensor = new Sensor();

            for (var i = 0; i < 10; i++)
            {
                var tirePressure = sensor.PopNextPressurePsiValue();
                
                _logger.WriteLine("{0}) {1}", i, tirePressure);
                
                Assert.InRange(tirePressure, 16, 22);   
            }
        }
    }
}