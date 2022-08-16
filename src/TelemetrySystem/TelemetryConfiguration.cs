using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TelemetrySystem
{
    public static class TelemetryConfiguration
    {
        public static string DiagnosticMessage = "AT#UD";
        public static string DiagnosticChannelConnectionString = "*111#";
        public static int RetryPolicy = 3;
    }
}
