using Marsexplorer.Test.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Marsexplorer.Test
{
    [TestClass]
    public class DirectionTest
    {
        [TestMethod]
        public void SimpleFill()
        {
            string dir = "archive";
            string f1 = "SimpleFill";
            int ex = 821;
            Tool.Single(dir, f1, ex);
        }

        [TestMethod]
        public void testinput()
        {
            string dir = "archive";
            string f1 = "testinput";
            int ex = 3128751;
            Tool.Single(dir, f1, ex);
        }

        [TestMethod]
        public void S1W10N1E20()
        {
            Tool.Move(new List<string> { "S 1", "W 10", "N 1", "E 20" }, 32);
        }

        [TestMethod]
        public void E1N10W1S20()
        {
            Tool.Move(new List<string> { "E 1", "N 10", "W 1", "S 20" }, 32);
        }

        [TestMethod]
        public void E1N2W1S2()
        {
            Tool.Move(new List<string> { "E 1", "N 2", "W 1", "S 2" }, 6);
        }

        [TestMethod]
        public void S1W2N1()
        {
            Tool.Move(new List<string> { "S 1", "W 2", "N 1" }, 5);
        }

        [TestMethod]
        public void S1W2N1E2()
        {
            Tool.Move(new List<string> { "S 1", "W 2", "N 1", "E 2" }, 6);
        }

        [TestMethod]
        public void N1E1N1W1N1()
        {
            Tool.Move(new List<string> { "N 1", "E 1", "N 1", "W 1", "N 1" }, 6);
        }

        [TestMethod]
        public void N1E1S1W2()
        {
            Tool.Move(new List<string> { "N 1", "E 1", "S 1", "W 2" }, 5);
        }

        [TestMethod]
        public void E1N1W1S3()
        {
            Tool.Move(new List<string> { "E 1", "N 1", "W 1", "S 3" }, 6);
        }

        [TestMethod]
        public void E1N1W1S2()
        {
            Tool.Move(new List<string> { "E 1", "N 1", "W 1", "S 2" }, 5);
        }

        [TestMethod]
        public void E1N1W1S1()
        {
            Tool.Move(new List<string> { "E 1", "N 1", "W 1", "S 1" }, 4);
        }

        [TestMethod]
        public void E1N1W1()
        {
            Tool.Move(new List<string> { "E 1", "N 1", "W 1" }, 4);
        }


        [TestMethod]
        public void E1N1()
        {
            Tool.Move(new List<string> { "E 1", "N 1" }, 3);
        }
    }
}
