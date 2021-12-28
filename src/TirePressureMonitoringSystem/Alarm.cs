namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        public bool AlarmOn { get; private set; }
        
        private ISensor _sensor { get; }
        private  AlarmConfiguration _configuration { get; }

        public Alarm()
        {
            _sensor = new Sensor();
            _configuration = new AlarmConfiguration();
        }
        public Alarm(ISensor sensor, AlarmConfiguration configuration)
        {
            _sensor = sensor;
            _configuration = configuration;
        }
        
        public void Check()
        {
            var psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < _configuration.LowPressureThreshold || _configuration.HighPressureThreshold < psiPressureValue)
            {
                AlarmOn = true;
            }
        }
    }
}
