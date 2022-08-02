namespace TDDMicroExercises.Common
{
    public sealed class AlarmConfiguration
    {
        public double LowPressureThreshold { get; }
        public double HighPressureThreshold { get; }

        public AlarmConfiguration(double lowPressureThreshold, double highPressureThreshold) =>
            (LowPressureThreshold, HighPressureThreshold) = (lowPressureThreshold, highPressureThreshold);
    }
}