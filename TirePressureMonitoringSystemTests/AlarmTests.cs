using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Claims;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TirePressureMonitoringSystemTests
{
    [TestClass]
    public class AlarmTests
    {
        [TestMethod]
        public void TooHighPressure()
        {

            Sensor sensor = new Sensor();
            sensor.SetPressureValue(22);
            Alarm alarm = new Alarm(sensor);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn == true);

        }

        [TestMethod]
        public void TooLowPressure()
        {
            Sensor sensor = new Sensor();
            sensor.SetPressureValue(15);
            Alarm alarm = new Alarm(sensor);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn == true);
        }

        [TestMethod]
        public void AccuratePressure()
        {
            Sensor sensor = new Sensor();
            sensor.SetPressureValue(18);
            Alarm alarm = new Alarm(sensor);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn == false);
        }

        [TestMethod]
        public void RandomPressure()
        {

            Sensor sensor = new Sensor();
            sensor.PopNextPressurePsiValue();
            Alarm alarm = new Alarm(sensor);
            alarm.Check();
            Assert.IsNotNull(alarm.AlarmOn);
            
        }

    }
}
