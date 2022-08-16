using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TelemetrySystem
{
    public interface ITelemetryDiagnosticControls
    {
        string DiagnosticInfo { get; set; }
        void CheckTransmission();
    }
}
