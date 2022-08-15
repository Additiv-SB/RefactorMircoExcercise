using TDDMicroExercises.TirePressureMonitoringSystem.Contracts;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private readonly ISensor _sensor;
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        public bool AlarmOn { get; private set; }

        public Alarm() : this(new Sensor())
        {
        }

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        public void Check()
        {
            var psiPressureValue = _sensor.PopNextPressurePsiValue();
            
            AlarmOn = psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue;
        }
    }
}