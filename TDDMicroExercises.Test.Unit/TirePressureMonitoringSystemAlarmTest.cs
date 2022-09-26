using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TDDMicroExercises.Test.Unit
{
    [TestClass]
    public class TirePressureMonitoringSystemAlarmTest
    {
        [TestMethod]
        public void NormalPressureValueNotRaiseAlarm()
        {
            //Arrange
            var alarm = new Alarm();

            //Act
            alarm.Check();

            //Assert

            Assert.AreEqual(false, alarm.AlarmOn);
        }

        [TestMethod]
        public void OutOfRangePressureValueShouldRaiseAlarm()
        {
            //Arrange
            var alarm = new Alarm();

            //Act
            alarm.Check();

            //Assert

            Assert.AreEqual(false, alarm.AlarmOn);
        }
    }
}