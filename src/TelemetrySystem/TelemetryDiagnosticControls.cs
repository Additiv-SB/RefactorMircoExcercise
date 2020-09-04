using System;
using Microsoft.Extensions.DependencyInjection;
using TDDMicroExercises.Base;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls : LogicBase, ITelemetryDiagnosticControls
    {
        private const string DiagnosticChannelConnectionString = "*111#";

        private readonly ITelemetryClient _telemetryClient;
        private string _diagnosticInfo = string.Empty;

        public TelemetryDiagnosticControls(ITelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        [Obsolete("Use DI to inject TDDMicroExercises.TelemetrySystem.ITelemetryDiagnosticControls")]
        public TelemetryDiagnosticControls()
        {
            _telemetryClient = ServiceProvider.GetService<ITelemetryClient>();
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

            int retryLeft = 3;
            while (_telemetryClient.OnlineStatus == false && retryLeft > 0)
            {
                _telemetryClient.Connect(DiagnosticChannelConnectionString);
                retryLeft -= 1;
            }

            if(_telemetryClient.OnlineStatus == false)
            {
                throw new Exception("Unable to connect.");
            }

            _telemetryClient.Send(TelemetryClient.DiagnosticMessage);
            _diagnosticInfo = _telemetryClient.Receive();
        }
    }
}
