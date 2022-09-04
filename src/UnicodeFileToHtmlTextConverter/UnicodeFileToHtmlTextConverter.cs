using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        private readonly IStreamReader _streamReader;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
        {
            _streamReader = new ReadFile(fullFilenameWithPath);
        }

        public UnicodeFileToHtmlTextConverter(IStreamReader fileReader)
        {
            _streamReader = fileReader;
        }

        public string ConvertToHtml()
        {
            string html = string.Empty;

            using (_streamReader)
            {
                foreach (var line in _streamReader.Read())
                {
                    html += HttpUtility.HtmlEncode(line);
                    html += "<br />";
                }
                return html;
            }
        }
    }
}