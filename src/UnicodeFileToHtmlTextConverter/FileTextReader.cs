using System.IO;
using System.Management.Instrumentation;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Contracts;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class FileTextReader : IFileTextReader
    {
        private TextReader _textReader;
        
        public IFileTextReader OpenFile(string fullFilePath)
        {
            if (!File.Exists(fullFilePath))
                throw new FileNotFoundException(fullFilePath);

            _textReader = File.OpenText(fullFilePath);

            return this;
        }

        public string ReadLine()
        {
            if (_textReader == null)
                throw new InstanceNotFoundException("OpenFile must be invoked before ReadLine");

            return _textReader.ReadLine();
        }

        public string[] ReadAllLines(string fullFilePath)
        {
            if (!File.Exists(fullFilePath))
                throw new FileNotFoundException(fullFilePath);

            return File.ReadAllLines(fullFilePath);
        }

        public void Dispose()
        {
            if (_textReader != null) _textReader.Dispose();
        }
    }
}