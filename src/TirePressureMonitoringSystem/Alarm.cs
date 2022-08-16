namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private readonly ISensor _sensor;
        public bool AlarmOn { get; private set; }

        public Alarm()
        {
            _sensor = new Sensor();
        }

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < AlarmConfiguration.LowPressureTreshold || AlarmConfiguration.HighPressureThreshold < psiPressureValue)
            {
                AlarmOn = true;
            }
        }

    }
}
