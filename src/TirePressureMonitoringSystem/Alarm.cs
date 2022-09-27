namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {

        private readonly ISensor _sensor;
        private  readonly AlarmProperties _alarmProperties;

        public Alarm()
        {
            _sensor = new Sensor();
            _alarmProperties = new AlarmProperties();
        }

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
            _alarmProperties = new AlarmProperties();
        }

        bool _alarmOn = false;

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < _alarmProperties.LowPressureThreshold || _alarmProperties.HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
