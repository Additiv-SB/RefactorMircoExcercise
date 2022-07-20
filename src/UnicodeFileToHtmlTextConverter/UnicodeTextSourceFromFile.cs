using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeTextSourceFromFile : IUnicodeTextSource
    {
        private readonly string _fullFilenameWithPath;

        public UnicodeTextSourceFromFile(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public TextReader ConnectToFile()
        {
            return File.OpenText(_fullFilenameWithPath);

        }
    }
}
