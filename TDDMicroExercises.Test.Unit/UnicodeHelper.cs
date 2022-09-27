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

        TextReader IUnicodeTextPath.ReadText()
        {
            return new StringReader(_text);
        }
    }
}
