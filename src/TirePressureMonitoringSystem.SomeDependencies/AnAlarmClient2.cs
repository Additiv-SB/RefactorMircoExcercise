namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient2
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.
        private readonly ISensor _sensor;
        public AnAlarmClient2(ISensor sensor)
        {
            _sensor = sensor;
        }

        private void DoSomething()
        {
            Alarm anAlarm = new Alarm(_sensor);
            anAlarm.Check();
            bool isAlarmOn = anAlarm.AlarmOn;
        }
    }
}
