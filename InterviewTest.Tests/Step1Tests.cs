using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewTest.Services;

namespace InterviewTest.Tests
{
    [TestClass]
    public class InterviewCriteria
    {
        [TestMethod]
        public void Step1_EmptyStringReturns0()
        {
            var summer = new StringSummer();
            var output = summer.Add("");

            Assert.AreEqual(0, output);
        }

        [TestMethod]
        public void Step1_SingleNumber()
        {
            var summer = new StringSummer();
            var output = summer.Add("123");

            Assert.AreEqual(123, output);
        }

        [TestMethod]
        public void Step1_TwoNumbers()
        {
            var summer = new StringSummer();
            var output = summer.Add("123,456");

            Assert.AreEqual(579, output);
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
    }
}
