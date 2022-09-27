namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class ASensorClient      
    {
        // A class with the only goal of simulating a dependency on Sensor
        // that has impact on the refactoring.
        private readonly ISensor _sensor;

        public ASensorClient(ISensor sensor)
        {
            _sensor = sensor;

            double value = _sensor.PopNextPressurePsiValue();
            value = _sensor.PopNextPressurePsiValue();
            value = _sensor.PopNextPressurePsiValue();
            value = _sensor.PopNextPressurePsiValue();
            
        }
    }
}
