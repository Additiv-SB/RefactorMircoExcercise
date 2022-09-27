namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient3
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.

        private readonly Alarm _anAlarm;
        private readonly ISensor _sensor;

        public AnAlarmClient3(ISensor sensor)
        {
            _sensor = sensor;
            _anAlarm = new Alarm(_sensor);
        }

        public void DoSomething()
        {
            _anAlarm.Check();
        }

        public void DoSomethingElse()
        {
            bool isAlarmOn = _anAlarm.AlarmOn;
        }
    }
}

