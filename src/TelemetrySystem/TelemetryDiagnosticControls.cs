using System;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls : ITelemetryDiagnosticControls
    {
        private readonly ITelemetryClient _telemetryClient;

        public TelemetryDiagnosticControls()
        {
            _telemetryClient = new TelemetryClient();
        }
        
        public TelemetryDiagnosticControls(ITelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        public string DiagnosticInfo { get; set; } = string.Empty;

        public void CheckTransmission()
        {
            DiagnosticInfo = string.Empty;

            _telemetryClient.Disconnect();
            int retryLeft = 3;
            while (_telemetryClient.OnlineStatus == false && retryLeft > 0)
            {
                _telemetryClient.Connect(TelemetryDiagnosticConfiguration.DiagnosticChannelConnectionString);
                retryLeft -= 1;
            }
             
            if (_telemetryClient.OnlineStatus == false)
            {
                throw new Exception("Unable to connect.");
            }

            _telemetryClient.Send(TelemetryDiagnosticConfiguration.DiagnosticMessage);
            DiagnosticInfo = _telemetryClient.Receive();
        }
    }
}
