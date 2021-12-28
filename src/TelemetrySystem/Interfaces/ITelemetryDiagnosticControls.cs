namespace TDDMicroExercises.TelemetrySystem.Interfaces
{
    public interface ITelemetryDiagnosticControls
    {
        string DiagnosticInfo { get;set; }
        void CheckTransmission();
    }
}
