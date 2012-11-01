using System;
using NUnit.Framework;

namespace RobotWars
{
    [TestFixture]
    public class RobotTest
    {
        private Grid _grid;
        private Coordinate _coord;
        private Robot _robot;

        [Test]
        public void CreateRobot()
        {
            _grid = new Grid(30, 30);
            _coord = new Coordinate(10, 11);
            _robot = new Robot(_coord, Orientation.N, _grid);

            Assert.AreEqual(_coord.X, _robot.Pos.X);
            Assert.AreEqual(_coord.Y, _robot.Pos.Y);
            Assert.AreEqual(Orientation.N, _robot.Or);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CreateRobotInvalidPosition()
        {
            _grid = new Grid(30, 30);
            _coord = new Coordinate(1, -1);
            _robot = new Robot(_coord, Orientation.N, _grid);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RobotMovesOffGrid()
        {
            _grid = new Grid(30, 30);
            _coord = new Coordinate(0, 0);
            _robot = new Robot(_coord, Orientation.S, _grid);

            _robot.Move(Instruction.M, _grid);
        }

        //Tests as defined in brief spec:
        //5 5

        [Test]
        public void FirstRobotMovementTest()
        {
            //1 2 N
            //LMLMLMLMM

            _grid = new Grid(5, 5);
            _robot = new Robot(new Coordinate(1, 2), Orientation.N, _grid);

            _robot.Move(Instruction.L, _grid);
            _robot.Move(Instruction.M, _grid);
            _robot.Move(Instruction.L, _grid);
            _robot.Move(Instruction.M, _grid);
            _robot.Move(Instruction.L, _grid);
            _robot.Move(Instruction.M, _grid);
            _robot.Move(Instruction.L, _grid);
            _robot.Move(Instruction.M, _grid);
            _robot.Move(Instruction.M, _grid);

            Assert.AreEqual(1, _robot.Pos.X);
            Assert.AreEqual(3, _robot.Pos.Y);
            Assert.AreEqual(Orientation.N, _robot.Or);
        }

        [Test]
        public void SecondRobotMovementTest()
        {
            //3 3 E
            //MMRMMRMRRM

            _robot = new Robot(new Coordinate(3, 3), Orientation.E, _grid);

            _robot.Move(Instruction.M, _grid);
            _robot.Move(Instruction.M, _grid);
            _robot.Move(Instruction.R, _grid);
            _robot.Move(Instruction.M, _grid);
            _robot.Move(Instruction.M, _grid);
            _robot.Move(Instruction.R, _grid);
            _robot.Move(Instruction.M, _grid);
            _robot.Move(Instruction.R, _grid);
            _robot.Move(Instruction.R, _grid);
            _robot.Move(Instruction.M, _grid);

            Assert.AreEqual(5, _robot.Pos.X);
            Assert.AreEqual(1, _robot.Pos.Y);
            Assert.AreEqual(Orientation.E, _robot.Or);
        }
    }
}
