using System.IO;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeTextFilePath : IUnicodeTextPath
    {
        private readonly string _fullFilenameWithPath;

        public UnicodeTextFilePath(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }
        public TextReader ReadText()
        {
            return File.OpenText(_fullFilenameWithPath);
        }
    }
}
