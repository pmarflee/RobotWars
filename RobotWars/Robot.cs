using System;

namespace RobotWars
{
    //Note orientation is sorted in clockwise order
    enum Orientation { N, E, S, W };
    enum Instruction { L, R, M }

    /// <summary>
    ///  Robot class controls creation and movement of instantiated robot object
    /// </summary>
    class Robot
    {
        //Limitations  of c# enum functionality means its size must be hard coded
        private const int NumOrientations = 4; 

        private Coordinate _pos;
        public Coordinate Pos
        {
            get
            {
                return _pos;
            }
        }

        private Orientation _or;
        public Orientation Or
        {
            get{
                return _or;
            }
        }

        public Robot(Coordinate pos, Orientation or, Grid grid)
        {
            if (!grid.IsValid(pos))
            {
                throw new Exception("Robot placed outside of grid");
            }

            _pos = pos;
            _or = or;
        }

        public void Move(Instruction inst, Grid grid)
        {
            switch (inst)
            {
                //Modulus used to cycle orientations. Limited definition of modulus with reference to negative
                //numbers result in initial incrementation by setsize to guarantee  positive result
                case Instruction.R:
                    _or = (Orientation)Enum.ToObject(typeof(Orientation), 
                        (((int)_or + NumOrientations + 1) % NumOrientations));
                    break;
                case Instruction.L:
                    _or = (Orientation)Enum.ToObject(typeof(Orientation), 
                        (((int)_or + NumOrientations - 1) % NumOrientations));
                    break;
                case Instruction.M:
                    Coordinate newPos;
                    switch (_or)
                    {
                        case Orientation.N:
                            newPos = new Coordinate(_pos.X, _pos.Y + 1);
                            break;
                        case Orientation.E:
                            newPos = new Coordinate(_pos.X + 1, _pos.Y);
                            break;
                        case Orientation.S:
                            newPos = new Coordinate(_pos.X, _pos.Y - 1);
                            break;
                        case Orientation.W:
                            newPos = new Coordinate(_pos.X - 1, _pos.Y);
                            break;
                        default:
                            newPos = new Coordinate(-1, -1);
                            break;
                    }
                    if (grid.IsValid(newPos))
                    {
                        _pos = newPos;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                break;
            }
        }
        
    }
}
