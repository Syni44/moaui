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

        [TestMethod]
        public void RemoveUnnecessarySpaceBeforeAndAfterTest() {
            // next, our input string has whitespace chars before the first name, between all
            // names, and after the last name.
            string str = "     Jane  A.      Doe   ";

            // test the extension method
            string newStr = str.RemoveUnnecessarySpace();

            // assert
            Assert.AreEqual(expected: "Jane A. Doe", actual: newStr);
        }

        [TestMethod]
        public void RemoveUnnecessarySpaceThrowbackTest() {
            // finally, we want to make sure the extension method throws back the string
            // as-is if it contains no space characters at all, as in a single name
            string str = "Ella";

            // test the extension method
            string newStr = str.RemoveUnnecessarySpace();

            // assert
            Assert.AreEqual(expected: "Ella", actual: newStr);
        }
    }
}
