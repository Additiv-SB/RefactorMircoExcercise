using System;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls : ITelemetryDiagnosticControls
    {
        // Private Properties
        #region Private Variable
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

            try
            {
                _telemetryClient.Disconnect();

                int retryLeft = 3;
                while (_telemetryClient.OnlineStatus == false && retryLeft > 0)
                {
                    _telemetryClient.Connect(DiagnosticChannelConnectionString);
                    retryLeft -= 1;
                }

                if (_telemetryClient.OnlineStatus == false)
                {
                    throw new Exception("Unable to connect.");
                }

                _telemetryClient.Send(TelemetryClient.DiagnosticMessage);

                _diagnosticInfo = _telemetryClient.Receive();
            }
            catch
            {
                throw;
            }
            finally
            {
                _telemetryClient.Disconnect();
            }
        }
        #endregion
    }
}
