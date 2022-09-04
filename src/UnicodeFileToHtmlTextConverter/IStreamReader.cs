using System;
using System.Collections.Generic;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public interface IStreamReader : IDisposable
    {
        IEnumerable<string> Read();
    }
}