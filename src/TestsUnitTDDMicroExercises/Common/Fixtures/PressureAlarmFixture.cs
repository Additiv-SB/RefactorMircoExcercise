using TDDMicroExercises.Common;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TestsUnitTDDMicroExercises.Common.Fixtures
{
    internal static class PressureAlarmFixture
    {
        public static Alarm WithPressureBoundary(
            double lowPressureThreshold,
            double highPressureThreshold,
            ISensor sensor) =>
            new Alarm(
                sensor,
                new AlarmConfiguration(lowPressureThreshold, highPressureThreshold));
    }
}