namespace TDDMicroExercises.TelemetrySystem.Abstractions
{
    public interface ITelemetryClient
    {
        bool OnlineStatus { get; }

        void Connect(string telemetryServerConnectionString);

        void Disconnect();
    }
}
