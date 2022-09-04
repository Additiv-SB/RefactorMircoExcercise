using System.Collections.Generic;
using System.IO;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class ReadFile : IStreamReader
    {
        private readonly string _fullFilenameWithPath;
        private TextReader _textReader;

        public ReadFile(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public IEnumerable<string> Read()
        {
            _textReader = File.OpenText(_fullFilenameWithPath);
            string line = _textReader.ReadLine();
            if (line != null)
            {
                yield return line;
            }
        }

        public void Dispose()
        {
            _textReader?.Dispose();
        }
    }
}