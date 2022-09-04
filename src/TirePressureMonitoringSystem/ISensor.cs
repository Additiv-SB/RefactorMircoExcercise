using System.Collections.Generic;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public interface ISensor
    {
        double PopNextPressurePsiValue();
    }
}