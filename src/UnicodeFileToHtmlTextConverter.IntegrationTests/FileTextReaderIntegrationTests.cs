using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.IntegrationTests
{
    public class FileTextReaderIntegrationTests
    {
        private readonly ITestOutputHelper _logger;

        private static readonly string FullFilePath =
            Path.Combine("UnicodeFileToHtmlTextConverter.IntegrationTests", "TextFile.txt");
        
        public FileTextReaderIntegrationTests(ITestOutputHelper logger)
        {
            _logger = logger;
        }

        [Fact]
        public void OpenFile_Ok()
        {
            var fileTextReader = new FileTextReader();

            fileTextReader.OpenFile(FullFilePath);
        }
        
        [Fact]
        public void ReadLines()
        {
            var fileTextReader = new FileTextReader();

            var ss = fileTextReader.ReadAllLines(FullFilePath);
            
            ss.ToList().ForEach(l => _logger.WriteLine(l));
        }
        
        [Fact]
        public void ReadLine_1()
        {
            var fileTextReader = new FileTextReader();

            fileTextReader.OpenFile(FullFilePath);
            
            var line = fileTextReader.ReadLine();
            
            Assert.Equal("1", line);
        }
        
        [Fact]
        public void ReadLine_LastLine_5()
        {
            var fileTextReader = new FileTextReader();

            fileTextReader.OpenFile(FullFilePath);
            
            var lastLine = string.Empty;

            while (true)
            {
                var currentLine = fileTextReader.ReadLine();
                
                if(currentLine == null)
                    break;

                lastLine = currentLine;
            }
            
            Assert.Equal("5", lastLine);
        }
    }
}