using System.IO;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    // Some notes:
    // This refactoring delivers necessary abstraction for unit testing with smallest number of changes.
    // Disposing objects not in the method where they were created may be not the best practise.
    // Another approeach would be to mock teh FileSystem by using IO.Abstraction,
    // Or processing data from the readers in the constructor and store the lines in an string array,
    // and loop thru this array in ConvertToHtml. This would add an extra loop.
    public class UnicodeFileToHtmlTextConverter
    {
        private readonly string _fullFilenameWithPath;
        private TextReader _reader;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
            _reader = File.OpenText(_fullFilenameWithPath);
        }

        public UnicodeFileToHtmlTextConverter(TextReader reader)
        {
            _reader = reader;
        }

        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = _reader)
            {
                string html = string.Empty;

                string line = unicodeFileStream.ReadLine();
                while (line != null)
                {
                    html += HttpUtility.HtmlEncode(line);
                    html += "<br />";
                    line = unicodeFileStream.ReadLine();
                }

                return html;
            }
        }
    }
}
