using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TestsUnitTDDMicroExercises.Common.Fixtures
{
    internal static class PressureSensorFixture
    {
        public static ISensor WithFixedPressureValue(double pressureValue)
        {
            var sensorMock = new Mock<ISensor>();

            sensorMock
               .Setup(mockedSensor => mockedSensor.PopNextPressurePsiValue())
               .Returns(pressureValue);

            return sensorMock.Object;
        }
    }
}