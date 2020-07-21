using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Tests
{
    [TestFixture]
    public class UnicodeFileToHtmlTextConverterTest
    {
        [Test]
        public void ConvertOneLineToHtmlTest()
        {
            var converter = new UnicodeFileToHtmlTextConverter(new StringReader("<sometext>"));
            var html = converter.ConvertToHtml();

            Assert.AreEqual("&lt;sometext&gt;<br />", html);
        }

        [Test]
        public void ConvertMultiLineToHtmlTest()
        {
            StringBuilder input = new StringBuilder();
            input.AppendLine("<First Line>");
            input.AppendLine("<Second Line>");
            input.AppendLine("<Third Line>");
            input.AppendLine("<<Fourth Line>>");

            StringBuilder expected = new StringBuilder();
            expected.Append("&lt;First Line&gt;<br />");
            expected.Append("&lt;Second Line&gt;<br />");
            expected.Append("&lt;Third Line&gt;<br />");
            expected.Append("&lt;&lt;Fourth Line&gt;&gt;<br />");


            var converter = new UnicodeFileToHtmlTextConverter(new StringReader(input.ToString()));
            var html = converter.ConvertToHtml();

            Assert.AreEqual(expected.ToString(), html);
        }

        [Test]
        public void ConvertSimpleTextToHtmlTest()
        {
            var converter = new UnicodeFileToHtmlTextConverter(new StringReader("Simple text"));
            var html = converter.ConvertToHtml();

            Assert.AreEqual("Simple text<br />", html);
        }

        [Test]
        public void ConvertEmptyTextToHtmlTest()
        {
            var converter = new UnicodeFileToHtmlTextConverter(new StringReader(string.Empty));
            var html = converter.ConvertToHtml();

            Assert.AreEqual(string.Empty, html);
        }
    }
}
