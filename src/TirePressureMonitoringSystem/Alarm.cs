using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm : IAlarm
    {
        private readonly ISensor _sensor;
        private bool _alarmOn = false;

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
                _alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
