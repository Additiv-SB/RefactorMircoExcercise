using TDDMicroExercises.Common;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    internal sealed class Alarm : IAlarm
    {
        private readonly ISensor _sensor;
        private readonly AlarmConfiguration _alarmConfiguration;

        public Alarm(ISensor sensor, AlarmConfiguration alarmConfiguration) =>
            (_sensor, _alarmConfiguration) = (sensor, alarmConfiguration);

        public bool AlarmOn { get; private set; }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            AlarmOn =
                psiPressureValue < _alarmConfiguration.LowPressureThreshold ||
                _alarmConfiguration.HighPressureThreshold < psiPressureValue;
        }
    }
}
