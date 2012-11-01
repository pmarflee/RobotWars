using System;

namespace RobotWars
{
    /// <summary>
    ///  Grid Class handles all grid creation and bounds checking
    /// </summary>
    class Grid
    {
        private readonly int _width;
        private readonly int _height;

        public Grid(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Grid invalid size");
            }

            _width = width;
            _height = height;
        }

        public bool IsValid(Coordinate coord)
        {
            return !(coord.X < 0 || coord.X > _width
                  || coord.Y < 0 || coord.Y > _height);
        }
    }
    
}
