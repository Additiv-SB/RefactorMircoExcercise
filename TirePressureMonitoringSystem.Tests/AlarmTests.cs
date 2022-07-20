using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TirePressureMonitoringSystem.Tests
{
    public class AlarmTests
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        [Fact]
        public void normal_pressure_value_should_not_cause_alarm()
        {
            var moqSensor = new Mock<ISensor>();
            moqSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(LowPressureThreshold);

            var test = new Alarm(moqSensor.Object);
            test.Check();


            Assert.True(!test.AlarmOn);
        }

        [Fact]
        public void out_of_range_pressure_value_should_cause_alarm() 
        {
            var moqSensor = new Mock<ISensor>();
            moqSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(LowPressureThreshold + HighPressureThreshold);

            var test = new Alarm(moqSensor.Object);
            test.Check();

            Assert.True(test.AlarmOn);
        }

        [Fact]
        public void on_create_Alarm_value_should_be_default()
        {
            var moqSensor = new Mock<ISensor>();
            moqSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(LowPressureThreshold + HighPressureThreshold);

            var test = new Alarm(moqSensor.Object);

            Assert.True(!test.AlarmOn);
        }


    }
}
