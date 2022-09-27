namespace TDDMicroExercises.Test.Unit;

[TestClass]
public class UnicodeFileToHtmlTextConverterTest
{
    /// <summary>
    /// Test method to assure that a new line is added when it's needed after Converting to HTML
    /// </summary>
    [TestMethod]
    public void AddingNewLineSuccessfully()
    {
        //Arrange
        string initialText = "First Line\nSecond Line\nThird Line";
        string expected = "First Line<br />Second Line<br />Third Line<br />";

        var mockString = new UnicodeHelper();
        mockString.GetText(initialText);

        //Act
        var convert = new UnicodeFileToHtmlTextConverter.UnicodeFileToHtmlTextConverter(mockString);
        string result = convert.ConvertToHtml();

        //Assert
        Assert.AreEqual(expected, result);
    }

    /// <summary>
    /// Test method for converting the &-ampersand sign
    /// </summary>
    [TestMethod]
    public void ConvertAmpersandSuccessfully()
    {
        //Arrange
        string initialText = "Wash & Go";
        string expectedText = "Wash &amp; Go<br />";

        var mockString = new UnicodeHelper();
        mockString.GetText(initialText);

        //Act
        var convert = new UnicodeFileToHtmlTextConverter.UnicodeFileToHtmlTextConverter(mockString);
        string result = convert.ConvertToHtml();

        //Assert
        Assert.AreEqual(expectedText, result);
    }
}