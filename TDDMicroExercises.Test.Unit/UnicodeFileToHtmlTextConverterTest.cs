namespace TDDMicroExercises.Test.Unit;

[TestClass]
public class UnicodeFileToHtmlTextConverterTest
{
    /// <summary>
    /// Test method to assure that a new line is added when it's needed after Converting to HTML
    /// </summary>
    [TestMethod]
    public void AddNewLine()
    {
        //Arrange
        string initialText = "First Line\nSecond Line\nThird Line";
        string expected = "First Line<br />Second Line<br />Third Line<br />";

        var mockString = new UnicodeHelper();
        mockString.GetText(initialText);

        var convert = new UnicodeFileToHtmlTextConverter.UnicodeFileToHtmlTextConverter(mockString);

        //Act
        string result = convert.ConvertToHtml();

        //Assert
        Assert.AreEqual(expected, result);
    }
}