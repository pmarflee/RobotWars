using System;
using NUnit.Framework;

namespace RobotWars
{
    [TestFixture]
    public class GridTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateGridNegative()
        {
            new Grid(-1, -1);
        }

        [Test]
        public void CreateCoordinate()
        {
            var coordinate = new Coordinate(10,20);
            Assert.AreEqual(10, coordinate.X);
            Assert.AreEqual(20, coordinate.Y);
        }
        
        [Test]
        public void TestIsValidTrue()
        {
            var grid = new Grid(30,30);
            Assert.IsTrue(grid.IsValid(new Coordinate(30,1)));
        }

        [Test]
        public void TestIsValidFalseNeg()
        {
            var grid = new Grid(30,30);
            Assert.IsFalse(grid.IsValid(new Coordinate(20,-1)));
        }            
            
        [Test]
        public void TestIsValidFalseTooHigh()
        {
            var grid = new Grid(30,30);
            Assert.IsFalse(grid.IsValid(new Coordinate(31,3)));
        }       
    }
}
