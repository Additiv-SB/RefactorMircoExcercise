using System;

namespace TDDMicroExercises.TelemetrySystem
{
    public sealed class TelemetryDiagnosticControls : ITelemetryDiagnosticControls
    {
        // Private Properties
        #region Private Properties
        private const string DiagnosticChannelConnectionString = "*111#";
        
        private readonly ITelemetryClient _telemetryClient;
        private string _diagnosticInfo = string.Empty;
        #endregion

        // Public Properties
        #region Public Properties
        public string DiagnosticInfo => _diagnosticInfo;
        #endregion

        // Constructors
        #region Constructors
        public TelemetryDiagnosticControls()
        {
            _telemetryClient = new TelemetryClient();
        }

        public TelemetryDiagnosticControls(ITelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
        }
        #endregion

        // Public Methods
        #region Public Methods
        public void CheckTransmission()
        {
            _diagnosticInfo = string.Empty;

            _telemetryClient.Disconnect();

            // Connect
            try
            {
                int retryLeft = 3;
                while (_telemetryClient.OnlineStatus == false && retryLeft > 0)
                {
                    _telemetryClient.Connect(DiagnosticChannelConnectionString);
                    retryLeft -= 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fail to connect: {ex.Message}");
            }

            if (_telemetryClient.OnlineStatus == false)
            {
                throw new Exception("Unable to connect.");
            }

            // Send message
            try
            {
                _telemetryClient.Send(TelemetryClient.DiagnosticMessage);
            }
            catch (Exception ex)
            {
                throw new Exception($"Fail to send message: {ex.Message}");
            }

            // Receive reponse message
            try
            {
                _diagnosticInfo = _telemetryClient.Receive();
            }
            catch (Exception ex)
            {
                throw new Exception($"Fail to receive message: {ex.Message}");
            }
        }
        #endregion
    }
}
