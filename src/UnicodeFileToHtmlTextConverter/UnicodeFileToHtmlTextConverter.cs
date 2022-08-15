using System.Linq;
using System.Text;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Contracts;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        private readonly string _fullFilenameWithPath;
        private readonly IFileTextReader _fileTextReader;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath) : this(fullFilenameWithPath,
            new FileTextReader())
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath, IFileTextReader fileTextReader)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
            _fileTextReader = fileTextReader;
        }

        public string ConvertToHtml()
        {
            var lines = _fileTextReader.ReadAllLines(_fullFilenameWithPath);

            return lines.Aggregate(new StringBuilder(), (b, s) => b.Append(s + "<br />")).ToString();
        }
    }
}