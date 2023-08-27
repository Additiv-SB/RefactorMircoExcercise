using System;
namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient2
    {
        private readonly Alarm _anAlarm;
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.
        public AnAlarmClient2(Alarm anAlarm)
        {
            _anAlarm = anAlarm;
        }
        private void DoSomething()
        {           
            _anAlarm.Check();
            bool isAlarmOn = _anAlarm.AlarmOn;
        }
    }
}
