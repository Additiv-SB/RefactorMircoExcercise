using System;
using System.IO;
using Moq;
using NUnit.Framework;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter;

namespace Tests
{
    [TestFixture]
    public class UnicodeFileToHtmlTextConverterTests
    {
        private readonly Mock<TextReader> _mockReader = new Mock<TextReader>();

        [Test]
        [TestCase(new [] { "abc def", "lalala"}, "abc def<br />lalala<br />")]
        [TestCase(new [] { @"< > \ &"}, @"&lt; &gt; \ &amp;<br />")]
        [TestCase(new [] { @"<", "", null }, @"&lt;<br /><br />")]
        [TestCase(new [] { @"<", "", null, "a" }, @"&lt;<br /><br />")]
        public void ConvertToHtml_SuccessfulReadingFromFile(string[] input, string expectedResult)
        {
            // Arrange
            var setupSequence = _mockReader.SetupSequence(reader => reader.ReadLine());
            foreach (var line in input)
            {
                setupSequence = setupSequence.Returns(line);
            }

            var converter = new UnicodeFileToHtmlTextConverter("xxx.logs");
            
            // Act
            var html = converter.ConvertToHtml(_mockReader.Object);
            
            // Assert
            Assert.AreEqual(expectedResult, html);
        }

        [Test]
        [TestCase(typeof(ArgumentNullException), null)]
        [TestCase(typeof(FileNotFoundException), "notExistingFilepath")]
        [TestCase(typeof(ArgumentException), "")]
        public void ConvertToHtml_IsNotValidFilepathArgument_ShouldTrowException(Type exceptionType, string filePath)
        {
            // Arrange
            var converter = new UnicodeFileToHtmlTextConverter(filePath);

            // Act & Assert
            Assert.Catch(exceptionType, () =>
            {
                converter.ConvertToHtml();
            }, $"Filepath is {filePath ?? "null"}. Expected: {exceptionType.FullName}");
        }
    }
}