using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TDDMicroExercises.Tests
{
	[TestClass]
	public class AlarmTests
	{
		[TestMethod]
		public void Check_NormalPressure_AlarmNotRaised()
		{
			//Arrange
			MockSensor mockSensor = new MockSensor();
			mockSensor.PopExpectedPressurePsiValue(Alarm.LowPressureThreshold);
			Alarm alarm = new Alarm(mockSensor);

			//Act
			alarm.Check();

			//Assert
			bool isAlarmOn = alarm.AlarmOn;
			Assert.AreEqual(false, isAlarmOn, "Tire pressure falls outside of the expected range. Alarm raised.");
		}

		[TestMethod]
		public void Check_PressureOutOfRange_AlarmRaised()
		{
			//Arrange
			MockSensor mockSensor = new MockSensor();
			mockSensor.PopExpectedPressurePsiValue(Alarm.LowPressureThreshold - 1);
			Alarm alarm = new Alarm(mockSensor);

			//Act
			alarm.Check();

			//Assert
			bool isAlarmOn = alarm.AlarmOn;
			Assert.AreEqual(false, isAlarmOn, "Tire pressure falls outside of the expected range. Alarm raised.");
		}

		[TestMethod]
		public void Check_RandomPressure_AlarmRaisedOrNot()
		{
			//Arrange
			MockSensor mockSensor = new MockSensor();
			mockSensor.PopRandomPressurePsiValue();
			Alarm alarm = new Alarm(mockSensor);

			//Act
			alarm.Check();

			//Assert
			bool isAlarmOn = alarm.AlarmOn;
			Assert.AreEqual(true, isAlarmOn, "Tire pressure falls outside of the expected range. Alarm raised.");
		}

		static IEnumerable<object[]> GetDataForTest()
		{
			return new[]
			{
				new object[] { Alarm.LowPressureThreshold, false },
				new object[] { Alarm.LowPressureThreshold-1, false },
				new object[] { Alarm.HighPressureThreshold, false },
				new object[] { Alarm.HighPressureThreshold+1, false }
			};
		}

		[TestMethod]
		[DynamicData(nameof(GetDataForTest), DynamicDataSourceType.Method)]
		public void Check_PressureOnceOkOnceNotOk_AlarmRaisedInTurn(double pressureValue, bool expected)
		{
			//Arrange
			MockSensor mockSensor = new MockSensor();
			mockSensor.PopExpectedPressurePsiValue(pressureValue);
			Alarm alarm = new Alarm(mockSensor);

			//Act
			alarm.Check();

			//Assert
			bool isAlarmOn = alarm.AlarmOn;
			Assert.AreEqual(expected, isAlarmOn, "Tire pressure falls outside of the expected range. Alarm raised.");
		}

	}
}
