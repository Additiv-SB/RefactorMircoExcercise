namespace TDDMicroExercises.TirePressureMonitoringSystem.Abstractions
{
    /// <summary>
    /// Entry point for handling Tire pressure.
    /// </summary>
    public interface ISensor
    {
        double PopNextPressurePsiValue();
    }
}
