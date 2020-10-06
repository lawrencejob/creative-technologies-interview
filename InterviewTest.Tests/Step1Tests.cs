using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewTest.Services;

namespace InterviewTest.Tests
{
    [TestClass]
    public class Step1Tests
    {
        [TestMethod]
        public void EmptyStringReturns0()
        {
            var summer = new StringSummer();
            var output = summer.Add("");

            Assert.AreEqual(0, output);
        }

        [TestMethod]
        public void SingleNumber()
        {
            var summer = new StringSummer();
            var output = summer.Add("123");

            Assert.AreEqual(123, output);
        }

        [TestMethod]
        public void TwoNumbers()
        {
            var summer = new StringSummer();
            var output = summer.Add("123,456");

            Assert.AreEqual(579, output);
        }
    }
}
