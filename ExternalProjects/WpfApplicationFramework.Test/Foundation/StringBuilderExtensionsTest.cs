using System;
using System.Text;
using System.Waf.Foundation;
using System.Waf.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Waf.Foundation
{
    [TestClass]
    public class StringBuilderExtensionsTest
    {
        [TestMethod]
        public void AppendInNewLineTest()
        {
            AssertHelper.ExpectedException<ArgumentNullException>(() =>
                StringBuilderExtensions.AppendInNewLine(null, "text"));

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendInNewLine("First Line");
            Assert.AreEqual("First Line", stringBuilder.ToString());

            stringBuilder.AppendInNewLine("Second Line");
            Assert.AreEqual("First Line" + Environment.NewLine + "Second Line", stringBuilder.ToString());

            stringBuilder.AppendInNewLine("Third Line");
            Assert.AreEqual("First Line" + Environment.NewLine + "Second Line" + Environment.NewLine
                + "Third Line", stringBuilder.ToString());
        }
    }
}
