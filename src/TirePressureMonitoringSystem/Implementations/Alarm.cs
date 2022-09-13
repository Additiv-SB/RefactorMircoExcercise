using TDDMicroExercises.TirePressureMonitoringSystem.Abstractions;
using TDDMicroExercises.TirePressureMonitoringSystem.Constants;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Implementations
{
    /// <summary>
    /// At first, provided solution did not satisfy the following SOLID principles:
    /// 1. Single responsibility principle - Alarm had concrete values for High and Low pressure which means that it had to be changed once these values are changed
    /// 2. Open Closed Principle - Alarm had concrete values for High and Low pressure and concrete Sensor implementation - those are reasons to change
    /// 3. Dependency Inversion Principle - Alarm should not depend on concrete implementation of Sensor, but rather on abstraction of it
    /// </summary>
    public class Alarm : IAlarm
    {
        private readonly ISensor _sensor;

        bool _alarmOn = false;

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

            if (psiPressureValue < TirePressureMonitoringSystemConstants.LowPressureThreshold || TirePressureMonitoringSystemConstants.HighPressureThreshold < psiPressureValue)
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
