

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm : IAlarm
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
            double psiPressureValue = this._sensor.PopNextPressurePsiValue();
            
            if (psiPressureValue < Helper.LowPressureThreshold || Helper.HighPressureThreshold < psiPressureValue)
            {
                AlarmOn = true;
            }

        }
    }
}
