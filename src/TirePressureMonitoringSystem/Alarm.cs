namespace TDDMicroExercises.TirePressureMonitoringSystem
{
	public class Alarm
	{
		public const double LowPressureThreshold = 17;
		public const double HighPressureThreshold = 21;

		bool _alarmOn = false;

		readonly ISensor _sensor;

		public Alarm(ISensor sensor)
		{
			_sensor = sensor;
		}

		public Alarm() : this(new Sensor()) { }

		public void Check()
		{
			double psiPressureValue = _sensor.PopNextPressurePsiValue();

			if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue) _alarmOn = true;
		}

		public bool AlarmOn
		{
			get { return _alarmOn; }
		}

	}
}
