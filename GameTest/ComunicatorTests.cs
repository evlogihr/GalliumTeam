using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game15;
using System.IO;
using System.Text;

namespace GameTest
{
    [TestClass]
    public class ComunicatorTests
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

        [TestMethod]
        public void TestGetName()
        {
            using (StringWriter sw = new StringWriter())
            {

                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("Pesho{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    string result = Communicator.GetName();
                    string expected = "Pesho";

                    Assert.AreEqual<string>(expected, result);
                }
            }
        }

        [TestMethod]
        public void TestDisplayIntroMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Communicator.DisplayIntroMessage();

                StringBuilder sb = new StringBuilder();
                sb.Append("Welcome to the game “15”.");
                sb.Append(Environment.NewLine + "Please try to arrange the numbers sequentially.");
                sb.Append(Environment.NewLine + "Commands:");
                sb.Append(Environment.NewLine + " - 'top' - view the top scoreboard");
                sb.Append(Environment.NewLine + " - 'restart' - start a new game");
                sb.Append(Environment.NewLine + " - 'exit' - quit the game");
                sb.Append(Environment.NewLine);

                string expected = sb.ToString();

                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}
