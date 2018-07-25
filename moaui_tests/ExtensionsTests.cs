using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using moaui.Models;

namespace moaui_tests
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void RemoveUnnecessarySpaceExcessTest() {
            // this string has a lot of excess space -- we want the extension method to remove
            // all available space except one between the first and last name
            string str = "Bob      Saget    ";

            // test the extension method
            string newStr = str.RemoveUnnecessarySpace();

            // assert
            Assert.AreEqual(expected: "Bob Saget", actual: newStr);
        }

        [TestMethod]
        public void RemoveUnnecessarySpaceAllowTest() {
            // this time, our string contains a single space between first name / last initial
            string str = "Cynthia P.";

            // test the extension method
            string newStr = str.RemoveUnnecessarySpace();

            // assert that the extension method does *not* remove that single space
            Assert.AreNotEqual(notExpected: "CynthiaP.", actual: newStr);
        }
    }
}
