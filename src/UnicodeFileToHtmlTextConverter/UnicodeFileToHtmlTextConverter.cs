using System.IO;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {

        private readonly IUnicodeTextPath _textPath;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
        {
            _textPath = new UnicodeTextFilePath(fullFilenameWithPath);
        }

        public UnicodeFileToHtmlTextConverter(IUnicodeTextPath textPath)
        {
            _textPath = textPath;
        }

        /// <summary>
        /// Convert text to HTML
        /// </summary>
        /// <returns></returns>
        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = _textPath.ReadText())
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
