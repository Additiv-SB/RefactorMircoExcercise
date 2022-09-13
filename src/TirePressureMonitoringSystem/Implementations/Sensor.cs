using System;
using TDDMicroExercises.TirePressureMonitoringSystem.Abstractions;
using TDDMicroExercises.TirePressureMonitoringSystem.Constants;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Implementations
{
    public class Sensor : ISensor
    {
        //
        // The reading of the pressure value from the sensor is simulated in this implementation.
        // Because the focus of the exercise is on the other class.
        //
        readonly Random _randomPressureSampleSimulator = new Random();


        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue = ReadPressureSample();

            return TirePressureMonitoringSystemConstants.Offset + pressureTelemetryValue;
        }

        private double ReadPressureSample()
        {
            // Simulate info read from a real sensor in a real tire
            return 6 * _randomPressureSampleSimulator.NextDouble() * _randomPressureSampleSimulator.NextDouble();
        }
    }
}
