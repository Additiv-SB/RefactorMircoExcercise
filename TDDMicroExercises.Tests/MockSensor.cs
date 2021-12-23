using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TDDMicroExercises.Tests
{
	class MockSensor : ISensor
	{
		readonly ISensor _sensor;

		public MockSensor()
		{
			_sensor = new Sensor();
		}

		public double PopNextPressurePsiValue()
		{
			return ExpectedValue;
		}

		public double PopExpectedPressurePsiValue(double expectedValue)
		{
			ExpectedValue = expectedValue;
			return expectedValue;
		}

		public double PopRandomPressurePsiValue()
		{
			ExpectedValue = _sensor.PopNextPressurePsiValue();
			return ExpectedValue;
		}


		private double _expectedValue;

		public double ExpectedValue
		{
			get { return _expectedValue; }
			set { _expectedValue = value; }
		}

	}
}
//Merry Christmas