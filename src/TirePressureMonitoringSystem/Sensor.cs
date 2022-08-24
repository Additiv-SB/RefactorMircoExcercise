using System;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Sensor:ISensor
    {
        //
        // The reading of the pressure value from the sensor is simulated in this implementation.
        // Because the focus of the exercise is on the other class.
        //

        private const double Offset = 16;
        private readonly Random _randomPressureSampleSimulator = new Random();
        private double _currentPressure;
        public double CurrentPressure { get { return _currentPressure; } }
        

        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue = ReadPressureSample();
            _currentPressure = Offset + pressureTelemetryValue;
            return CurrentPressure;
        }

        public void SetPressureValue(double psiValue)
        {
            _currentPressure = psiValue;
        }

        private double ReadPressureSample()
        {
            // Simulate info read from a real sensor in a real tire
            return 6 * _randomPressureSampleSimulator.NextDouble() * _randomPressureSampleSimulator.NextDouble();
        }
    }
}
