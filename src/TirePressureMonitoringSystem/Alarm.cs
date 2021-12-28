using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm : IAlarm
    {
        private readonly ISensor _sensor;

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

            if (psiPressureValue < PressureConfiguration.LowPressureThreshold || PressureConfiguration.HighPressureThreshold < psiPressureValue)
            {
                AlarmOn = true;
            }
        }

        public bool AlarmOn { get; private set; }
    }
}
