using System.IO;
using System.Text;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        private readonly string _fullFilenameWithPath;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public string ConvertToHtml()
        {
            using (var unicodeFileStream = File.OpenText(_fullFilenameWithPath))
            {
                return ConvertToHtml(unicodeFileStream);
            }
        }

        public string ConvertToHtml(TextReader reader)
        {
            var sb = new StringBuilder();

            var line = reader.ReadLine();
            while (line != null)
            {
                sb.Append(HttpUtility.HtmlEncode(line));
                sb.Append("<br />");
                line = reader.ReadLine();
            }

            return sb.ToString();
        }
    }
}
