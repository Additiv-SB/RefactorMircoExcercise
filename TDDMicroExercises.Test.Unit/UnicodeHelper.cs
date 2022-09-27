using TDDMicroExercises.UnicodeFileToHtmlTextConverter;

namespace TDDMicroExercises.Test.Unit
{
    public class UnicodeHelper : IUnicodeTextPath
    {
        private string _text;

        public void GetText(string text)
        {
            _text = text;
        }

        /// <summary>
        /// Helper for TestMethod to return the provided string
        /// </summary>
        /// <returns></returns>
        TextReader IUnicodeTextPath.ReadText()
        {
            return new StringReader(_text);
        }
    }
}
