using System;
using TDDMicroExercises.TelemetrySystem.Abstractions;
using TDDMicroExercises.TelemetrySystem.Constants;

namespace TDDMicroExercises.TelemetrySystem.Implementations
{
    public class TelemetryDiagnosticControls : ITelemetryDiagnosticControls
    {
        private readonly ITelemetryClient _telemetryClient;
        private readonly ITelemetryTransmitter _telemetryTransmitter;
        private string _diagnosticInfo = string.Empty;

        public TelemetryDiagnosticControls()
        {
            _telemetryClient = new TelemetryClient();
        }

        public TelemetryDiagnosticControls(ITelemetryClient telemetryClient, ITelemetryTransmitter telemetryTransmitter)
        {
            _telemetryClient = telemetryClient;
            _telemetryTransmitter = telemetryTransmitter;
        }

        public string DiagnosticInfo
        {
            get { return _diagnosticInfo; }
            set { _diagnosticInfo = value; }
        }

        public void CheckTransmission()
        {
            _diagnosticInfo = string.Empty;

            _telemetryClient.Disconnect();

            int retryLeft = TelemetrySystemConstants.RetryPolicy;
            while (_telemetryClient.OnlineStatus == false && retryLeft > 0)
            {
                _telemetryClient.Connect(TelemetrySystemConstants.DiagnosticChannelConnectionString);
                retryLeft -= 1;
            }

            if (_telemetryClient.OnlineStatus == false)
            {
                throw new Exception("Unable to connect.");
            }

            _telemetryTransmitter.Send(TelemetrySystemConstants.DiagnosticMessage);
            _diagnosticInfo = _telemetryTransmitter.Receive();
        }
    }
}
