namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public sealed class Alarm : IAlarm
    {
        // Private Properties
        #region Private Properties
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private bool _alarmOn = false;
        private readonly ISensor _sensor;
        #endregion

        // Public Properties
        #region Public Properties
        public bool AlarmOn => _alarmOn;
        #endregion

        // Constructors
        #region Constructors
        public Alarm()
        {
            _sensor = new Sensor();
        }

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }
        #endregion

        // Public Methods
        #region Public Methods
        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            _alarmOn = psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue;
        }
        #endregion
    }
}
