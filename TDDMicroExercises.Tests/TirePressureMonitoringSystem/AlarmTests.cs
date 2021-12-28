using FluentAssertions;
using TDDMicroExercises.TirePressureMonitoringSystem;
using Xunit;

namespace TDDMicroExercises.Tests.TirePressureMonitoringSystem
{
    public class AlarmTests
    {
        [Fact]
        public void AlarmOn_WhenAlarmObjectCreated_SetToDefault()
        {
            bool defaultAlarmOnValue = false;
            
            Alarm alarm = new Alarm();

            alarm.AlarmOn.Should().Be(defaultAlarmOnValue);
        }
    }

}

