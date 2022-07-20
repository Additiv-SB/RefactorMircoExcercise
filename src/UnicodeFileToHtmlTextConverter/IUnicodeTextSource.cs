using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public interface IUnicodeTextSource
    {
        TextReader ConnectToFile();
    }
}
