using System;
using TDDMicroExercises.Common;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient1
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.

        public AnAlarmClient1(IAlarm alarm)
        {
            IAlarm anAlarm = alarm;
            anAlarm.Check();
            bool isAlarmOn = anAlarm.AlarmOn;
        }
    }
}
