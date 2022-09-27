namespace TDDMicroExercises.Test.Unit
{
    [TestClass]
    public class UnicodeFileToHtmlTextConverterTest
    {
        [TestMethod]
        public void AddNewLine()
        {
            //Arrange
            string textSource = "First Line<br /> Second Line<br /> Third Line"; 
            var convert = new UnicodeFileToHtmlTextConverter.UnicodeFileToHtmlTextConverter(textSource);

            //Act
            string result = convert.ConvertToHtml();

            //Assert
            Assert.AreEqual(result, textSource);
        }
    }
}
