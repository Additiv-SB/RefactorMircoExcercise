using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter;
using System.IO;

namespace ClassLibrary1
{
    public class UnicodeFileToHtmlTextConverterTests
    {
        [Fact]
        public void on_convert_should_add_breakline() 
        {
            // any idea for moq
            var moqData = new Mock<IUnicodeTextSource>();
           // moqData.Setup(x => x.ConnectToFile())
        }
    }
}
