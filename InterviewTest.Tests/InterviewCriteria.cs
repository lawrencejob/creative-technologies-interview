using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System;
using InterviewTest.Services;

namespace InterviewTest.Tests
{
    [TestClass]
    public class InterviewCriteria
    {

        private IStringSummer _stringSummer;
      
        [TestInitialize]
        public void Setup()
        {
            var serviceProvider = Program.BuildServices();

            _stringSummer = serviceProvider.GetService<IStringSummer>();
        }

        [DataTestMethod]
        [DataRow("", 0, DisplayName = "Empty string returns 0")]
        [DataRow("123", 123, DisplayName = "Single number returns self")]
        [DataRow("123,456", 579, DisplayName = "Two numbers add successfully")]
        public void Step1_VerifyBasicStrings(string input, int expected)
        {
            var output = _stringSummer.Add(input);

            Assert.AreEqual(expected, output);
        }

        [DataTestMethod]
        [DataRow("1,2,3,4,5,6,7,8,9", 45)]
        [DataRow("123,54,534,465,1,2,3", 1182)] 
        public void Step2_AnyNumberOfNumbers(string input, int expected)
        {
            var output = _stringSummer.Add(input);

            Assert.AreEqual(expected, output);
        }

        [DataTestMethod]
        [DataRow("1,2,3\n4,5,6,7,8,9", 45)]
        [DataRow("123,54,534,465,1,2\n3", 1182)]
        public void Step3_AllowNewLinesAndCommas(string input, int expected)
        {
            var output = _stringSummer.Add(input);

            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Step3_DisallowDoubleDelimiter()
        {
            var output = _stringSummer.Add("1,\n");
        }

        [TestMethod]
        public void Step4_AllowCustomDelimiter()
        {
            
            var output = _stringSummer.Add("//;\n1;2;3;4");

            Assert.AreEqual(10, output);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Step5_DisallowNegativeNumbers()
        {
            var output = _stringSummer.Add("1,-5,3,4,5");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Step5_DisallowMultipleNegativeNumbers()
        {
            var output = _stringSummer.Add("1,-5,-3,4,5");
        }

        [TestMethod]
        public void Step6_IgnoreNumbersOver1000()
        {

            var output = _stringSummer.Add("2,1001,13");

            Assert.AreEqual(15, output);
        }

        [TestMethod]
        public void Step7_AllowMultipleDelimiters()
        {
            var output = _stringSummer.Add("//*%\n1*2%3");

            Assert.AreEqual(6, output);
        }
    }
}
