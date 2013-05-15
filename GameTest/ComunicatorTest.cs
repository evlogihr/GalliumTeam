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



                using (StringReader sr = new StringReader(string.Format("6{0}", Environment.NewLine)))
                {
                    
                    Console.SetIn(sr);

                    string result = Communicator.GetNumber();





                    string expected = "5";//string.Format("Enter a number to move: {0}", Environment.NewLine);

                    Assert.AreEqual<string>(expected, result, "expected {0}", expected);

                }

            }
        }
    }
}
