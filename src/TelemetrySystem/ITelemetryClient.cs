using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TelemetrySystem
{
    public interface ITelemetryClient
    {
        bool OnlineStatus { get; }

        void Connect(string telemetryServerConnectionString);

        void Disconnect();

        void Send(string message);

        string Receive();
    }
}
