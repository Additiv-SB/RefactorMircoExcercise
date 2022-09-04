using System.Collections.Generic;
using Moq;
using Xunit;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter;
using System.IO;
using System;

namespace TDDMicroExercisesTests
{
    public class UnicodeFileToHtmlTextConverterUnitTests
    {
        [Fact]
        public void ConvertToHtmlTest()
        {
            var lines = new List<string> { "abc", "def" };

            var streamReaderMock = new Mock<IStreamReader>();
            streamReaderMock.Setup(sr => sr.Read()).Returns(lines);

            var sut = new UnicodeFileToHtmlTextConverter(streamReaderMock.Object);
            var html = sut.ConvertToHtml();
            Assert.True(html.Contains(lines[0]));
            Assert.True(html.Contains(lines[1]));

            streamReaderMock.Verify(mock => mock.Dispose(), Times.Once());
        }

        [Fact]
        public void FileEmptyTest()
        {
            var streamReaderMock = new Mock<IStreamReader>();
            streamReaderMock.Setup(sr => sr.Read()).Returns(new List<string>());

            var sut = new UnicodeFileToHtmlTextConverter(streamReaderMock.Object);
            var html = sut.ConvertToHtml();
            Assert.Empty(html);
        }
    }
}