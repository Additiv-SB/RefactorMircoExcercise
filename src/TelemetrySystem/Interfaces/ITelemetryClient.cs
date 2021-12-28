namespace TDDMicroExercises.TelemetrySystem.Interfaces
{
    public interface ITelemetryClient
    {
        void Send(string message);
        string Receive();
        void Connect(string telemetryServerConnectionString);
        void Disconnect();
        bool OnlineStatus { get; }
    }
}
