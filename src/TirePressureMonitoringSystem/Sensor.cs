using System;
using TDDMicroExercises.TirePressureMonitoringSystem.Contracts;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Sensor : ISensor
    {
        private const double Offset = 16;
        private static readonly Random RandomPressureSampleSimulator = new Random();

        public double PopNextPressurePsiValue()
        {
            var pressureTelemetryValue = ReadPressureSample();

            return Offset + pressureTelemetryValue;
        }

        internal virtual double ReadPressureSample()
        {
            return 6 * RandomPressureSampleSimulator.NextDouble() * RandomPressureSampleSimulator.NextDouble();
        }
    }
}
