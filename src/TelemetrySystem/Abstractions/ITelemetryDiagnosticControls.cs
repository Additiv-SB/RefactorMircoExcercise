namespace TDDMicroExercises.TelemetrySystem.Abstractions
{
    public interface ITelemetryDiagnosticControls
    {
        string DiagnosticInfo { get; set; }
        void CheckTransmission();
    }
}
