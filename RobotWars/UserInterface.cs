using System;
using System.Globalization;

namespace RobotWars
{
    /// <summary>
    ///  This class provides a simple commandline user interface
    /// </summary>
    class UserInterface
    {
        private static Grid _grid;
        private static Robot _robot;

        /// <summary>
        ///  Main method - invoked upon run.
        /// </summary>
        static void Main()
        {
            //Read initial input defining grid dimensions
            Console.Write("Enter the grid dimensions (e.g. 5 5): ");
            var gridSizeInput = Console.ReadLine();
            var gridSizeTokens = gridSizeInput.Split();
            try
            {
                CreateGrid(int.Parse(gridSizeTokens[0]), int.Parse(gridSizeTokens[1]));
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid Grid Definition");
                return;
            }

            //Loop input reading for all robots until termination
            while (true)
            {

                //Read initial robot position and orientation
                Console.Write("Enter the robot's initial position and orientation (e.g. 1 1 E): ");
                var robotPositionInput = Console.ReadLine();
                if (string.IsNullOrEmpty(robotPositionInput))
                {
                    break;
                }
                var robotPositionTokens = robotPositionInput.Split();

                try
                {
                    CreateRobot(int.Parse(robotPositionTokens[0]), int.Parse(robotPositionTokens[1]), robotPositionTokens[2]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Invalid Robot Definition");
                    break;
                }

                //Read set of instructions (as single spaceless string)
                Console.WriteLine("Enter a list of commands to move the robot. Valid commands are L, R, and M: ");
                var robotCommandsInput = Console.ReadLine();
                try
                {
                    foreach (var instruction in robotCommandsInput)
                    {
                        try
                        {
                            _robot.Move((Instruction)Enum.Parse(typeof(Instruction), instruction.ToString(CultureInfo.InvariantCulture), true), _grid);
                        }
                        catch (ArgumentException)
                        {
                            throw new Exception(string.Format("Command '{0}' is invalid.  Should be L, R, or M.", instruction));
                        }
                        catch (InvalidOperationException)
                        {
                            throw new Exception("Robot cannot move off the grid");
                        }
                        catch (Exception e)
                        {
                            throw new Exception(string.Format("Internal error: {0}", e.Message));
                        }
                    }

                    Console.WriteLine("{0} {1}", _robot.Pos, _robot.Or);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }
        }

        /// <summary>
        ///  Static method creates singleton grid of specified width and height
        /// </summary>
        private static void CreateGrid(int width, int height)
        {
            _grid = new Grid(width, height);
        }

        /// <summary>
        ///  Static method creates a new robot at a specified position and orientation
        /// </summary>
        private static void CreateRobot(int x, int y, String orientation)
        {
            var pos = new Coordinate(x, y);
            _robot = new Robot(pos, (Orientation)Enum.Parse(typeof(Orientation), orientation, true), _grid);
        }
    }
}
