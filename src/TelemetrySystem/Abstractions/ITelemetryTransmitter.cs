namespace TDDMicroExercises.TelemetrySystem.Abstractions
{
    public interface ITelemetryTransmitter
    {
        void Send(string message);

        string Receive();
    }
}
