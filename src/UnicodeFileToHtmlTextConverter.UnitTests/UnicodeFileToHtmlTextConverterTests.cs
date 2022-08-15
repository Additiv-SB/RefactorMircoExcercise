using System;
using Moq;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Contracts;
using Xunit;
using Xunit.Abstractions;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.UnitTests
{
    public class UnicodeFileToHtmlTextConverterTests
    {
        private readonly ITestOutputHelper _logger;
        public UnicodeFileToHtmlTextConverterTests(ITestOutputHelper logger)
        {
            _logger = logger;
        }
        
        [Fact]
        public void ConvertToHtml_single_line()
        {
            var fileTextReaderMock = new Mock<IFileTextReader>();

            fileTextReaderMock.Setup(f => f.ReadAllLines(It.IsAny<string>())).Returns(new[] { "1" });
            
            var unicodeFileToHtmlTextConverter =
                new UnicodeFileToHtmlTextConverter(Guid.NewGuid().ToString(), fileTextReaderMock.Object);
            
            Assert.Equal("1<br />", unicodeFileToHtmlTextConverter.ConvertToHtml());
        }
        
        [Fact]
        public void ConvertToHtml_multi_line()
        {
            var fileTextReaderMock = new Mock<IFileTextReader>();

            fileTextReaderMock.Setup(f => f.ReadAllLines(It.IsAny<string>())).Returns(new[] { "1", "2" });
            
            var unicodeFileToHtmlTextConverter =
                new UnicodeFileToHtmlTextConverter(Guid.NewGuid().ToString(), fileTextReaderMock.Object);
            
            Assert.Equal("1<br />2<br />", unicodeFileToHtmlTextConverter.ConvertToHtml());
        }
        
        [Fact]
        public void ConvertToHtml_no_lines()
        {
            var fileTextReaderMock = new Mock<IFileTextReader>();

            fileTextReaderMock.Setup(f => f.ReadAllLines(It.IsAny<string>())).Returns(new string[] {});
            
            var unicodeFileToHtmlTextConverter =
                new UnicodeFileToHtmlTextConverter(Guid.NewGuid().ToString(), fileTextReaderMock.Object);
            
            Assert.Equal(string.Empty, unicodeFileToHtmlTextConverter.ConvertToHtml());
        }
    }
}