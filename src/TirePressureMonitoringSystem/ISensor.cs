namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public interface ISensor
    {
        /// <summary>
        /// Read the pressure value from the sensor
        /// </summary>
        /// <returns></returns>
        double PopNextPressurePsiValue();
    }
}
