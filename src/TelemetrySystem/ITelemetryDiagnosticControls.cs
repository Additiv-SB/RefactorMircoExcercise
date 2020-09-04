namespace TDDMicroExercises.TelemetrySystem
{
    public interface ITelemetryDiagnosticControls
    {
        string DiagnosticInfo { get; }

        void CheckTransmission();
    }
}
