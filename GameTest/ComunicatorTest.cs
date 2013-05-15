using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game15;
using System.IO;

namespace GameTest
{
    [TestClass]
    public class ComunicatorTest
    {
        [TestMethod]
        public void TestGetNumber()
        {
            using (StringWriter sw = new StringWriter())
            {

                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("5{0}", Environment.NewLine)))
                {
                    
                    Console.SetIn(sr);

                    string result = Communicator.GetNumber();

                    string expected = "5";

                    Assert.AreEqual<string>(expected, result);
                }
            }
        }

        [TestMethod]
        public void TestDisplayMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                string message = "Test message";
                Communicator.DisplayMessage(message);

                string expected = string.Format("Test message{0}", Environment.NewLine);

                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

    }


}
