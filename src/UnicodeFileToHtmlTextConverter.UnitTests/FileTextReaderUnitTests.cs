using System;
using System.IO;
using System.Management.Instrumentation;
using Xunit;
using Xunit.Abstractions;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.UnitTests
{
    public class FileTextReaderUnitTests
    {
        private readonly ITestOutputHelper _logger;

        public FileTextReaderUnitTests(ITestOutputHelper logger)
        {
            _logger = logger;
        }

        [Fact]
        public void OpenFile_FileNotFoundException()
        {
            var fileTextReader = new FileTextReader();

            Assert.Throws<FileNotFoundException>(() => fileTextReader.OpenFile(Guid.NewGuid().ToString()));
        }
        
        [Fact]
        public void ReadLine_InstanceNotFoundException()
        {
            var fileTextReader = new FileTextReader();

            Assert.Throws<InstanceNotFoundException>(() => fileTextReader.ReadLine());
        }
    }
}