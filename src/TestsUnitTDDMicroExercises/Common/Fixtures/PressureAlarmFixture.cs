using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TestsUnitTDDMicroExercises.Common.Fixtures
{
    internal static class PressureAlarmFixture
    {
        public static Alarm WithPressureBoundary(double lowPressureThreshold, double highPressureThreshold)
        {
            return new Alarm();
        }
    }
}