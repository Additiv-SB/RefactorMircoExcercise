using System.IO;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        private readonly IUnicodeTextSource _textSource;


        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
        {
            _textSource = new UnicodeTextSourceFromFile(fullFilenameWithPath);
        }

        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = _textSource.ConnectToFile())
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
