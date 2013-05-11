using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game15;

namespace GameTest
{
    [TestClass]
    public class CoordinatesTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Row value cannot be negative.")]
        public void TestRowWithNegativeValue()
        {
            Coordinates point = new Coordinates(-1, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Col value cannot be negative.")]
        public void TestColWithNegativeValue()
        {
            Coordinates point = new Coordinates(3, -4);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Coordinates point = new Coordinates(3, 5);

            Assert.AreEqual(point.Row, 3);
            Assert.AreEqual(point.Col, 5);
        }

        [TestMethod]
        public void TestDiagonalNeighbour()
        {
            Coordinates currentPoint = new Coordinates(1, 1);
            Coordinates otherPoint = new Coordinates(2, 2);

            bool result = currentPoint.CheckNeighbour(otherPoint);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestVerticalNeighbour()
        {
            Coordinates currentPoint = new Coordinates(1, 1);
            Coordinates otherPoint = new Coordinates(1, 2);

            bool result = currentPoint.CheckNeighbour(otherPoint);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestHorizontalNeighbour()
        {
            Coordinates currentPoint = new Coordinates(1, 1);
            Coordinates otherPoint = new Coordinates(2, 1);

            bool result = currentPoint.CheckNeighbour(otherPoint);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestFarNeighbour()
        {
            Coordinates currentPoint = new Coordinates(1, 1);
            Coordinates otherPoint = new Coordinates(9, 9);

            bool result = currentPoint.CheckNeighbour(otherPoint);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Points cannot dublicate.")]
        public void TestForDublicatedPoints()
        {
            Coordinates currentPoint = new Coordinates(1, 1);
            Coordinates otherPoint = new Coordinates(1, 1);

            bool result = currentPoint.CheckNeighbour(otherPoint);         
        }
    }
}
