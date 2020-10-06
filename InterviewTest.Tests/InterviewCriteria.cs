using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InterviewTest.Services;

namespace InterviewTest.Tests
{
    [TestClass]
    public class InterviewCriteria
    {
        [DataTestMethod]
        [DataRow("", 0, DisplayName = "Empty string returns 0")]
        [DataRow("123", 123, DisplayName = "Single number returns self")]
        [DataRow("123,456", 579, DisplayName = "Two numbers add successfully")]
        public void Step1_VerifyBasicStrings(string input, int expected)
        {
            var summer = new StringSummer();
            var output = summer.Add(input);

            Assert.AreEqual(expected, output);
        }

        [DataTestMethod]
        [DataRow("1,2,3,4,5,6,7,8,9", 45)]
        [DataRow("123,1354,34534,4654,1,2,3", 40671)]
        public void Step2_AnyNumberOfNumbers(string input, int expected)
        {
            var summer = new StringSummer();
            var output = summer.Add(input);

            Assert.AreEqual(expected, output);
        }

        [DataTestMethod]
        [DataRow("1,2,3\n4,5,6,7,8,9", 45)]
        [DataRow("123,1354,34534,4654,1,2\n3", 40671)]
        public void Step3_AllowNewLinesAndCommas(string input, int expected)
        {
            var summer = new StringSummer();
            var output = summer.Add(input);

            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Step3_DisallowDoubleDelimiter()
        {
            var summer = new StringSummer();
            var output = summer.Add("1,\n");
        }

        [TestMethod]
        public void Step4_AllowCustomDelimiter()
        {
            
            var summer = new StringSummer();
            var output = summer.Add("//;\n1;2;3;4");

            Assert.AreEqual(10, output);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Step5_DisallowNegativeNumbers()
        {
            var summer = new StringSummer();
            var output = summer.Add("1,-5,3,4,5");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Step5_DisallowMultipleNegativeNumbers()
        {
            var summer = new StringSummer();
            var output = summer.Add("1,-5,-3,4,5");
        }
    }
}
