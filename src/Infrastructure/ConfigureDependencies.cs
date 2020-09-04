using Microsoft.Extensions.DependencyInjection;
using TDDMicroExercises.TelemetrySystem;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TDDMicroExercises.Infrastructure
{
    //Register app dependencies
    public static class ConfigureDependencies
    {
        internal static IServiceCollection AddAppDependencies(this ServiceCollection serviceProvider)
        {
            serviceProvider
                .AddTransient<ISensor, Sensor>()
                .AddTransient<IAlarm, Alarm>()
                .AddTransient<ITelemetryClient, TelemetryClient>()
                .AddTransient<ITelemetryDiagnosticControls, TelemetryDiagnosticControls>();

            return serviceProvider;
        }
    }
}
