namespace RobotWars
{
    /// <summary>
    ///  Lightweight struct used to keep coordinate information together
    ///  ToString method overridden to allow cleaner printing of coordinates
    /// </summary>
    public struct Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Override the ToString method:
        public override string ToString()
        {
            return (string.Format("{0} {1}", X, Y));
        }
    }
}
