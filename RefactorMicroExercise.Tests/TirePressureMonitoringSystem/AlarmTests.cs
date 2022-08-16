using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDMicroExercises.TirePressureMonitoringSystem;
using Xunit;

namespace RefactorMicroExercise.Tests.TirePressureMonitoringSystem
{
    public class AlarmTests
    {
        [Fact]
        public void AlarmOn_SHouldReturnFalseByDefault()
        {
            bool defaultValue = false;

            Alarm alarm = new Alarm();

            Assert.Equal(defaultValue, alarm.AlarmOn);
        }
    }
}
