using SpiderRobotBAL.Common;
using static SpiderRobotBAL.Common.Enums;

namespace SpiderRobotBAL
{
    public class SpiderRobo
    {
        public  int XCordinate { get; set; }
        public  int YCordinate { get; set; }
        public Orientation CurrentOrientation { get; set; }

        private IValidator<SpiderRobo> validator;
        public SpiderRobo(int xCord,int yCord, string orientation , IValidator<SpiderRobo> spiderRobotValidator)
        {
            XCordinate= xCord;
            YCordinate= yCord;
            if (orientation == "LEFT")
                CurrentOrientation = Orientation.Left;
            else if (orientation == "RIGHT")
                CurrentOrientation = Orientation.Right;

            validator = spiderRobotValidator;
           
        }


        public void ProcessInput(char input)
        {
            switch (input)
            {
                case 'F':
                    ProcessForward();
                    break;
                case 'R':
                    ProcessRight();
                    break;
                case 'L':
                    ProcessLeft();
                    break;
            }
        }

        private void ProcessLeft()
        {
            switch (CurrentOrientation)
            {
                case Orientation.Left:
                    CurrentOrientation = Orientation.Down;
                    break;
                case Orientation.Right:
                    CurrentOrientation = Orientation.Up;
                    break;
                case Orientation.Up:
                    CurrentOrientation = Orientation.Left;
                    break;
                case Orientation.Down:
                    CurrentOrientation = Orientation.Right;
                    break;
            }
        }

        private void ProcessRight()
        {

            switch (CurrentOrientation)
            {
                case Orientation.Left:
                    CurrentOrientation = Orientation.Up;
                    break;
                case Orientation.Right:
                    CurrentOrientation = Orientation.Down;
                    break;
                case Orientation.Up:
                    CurrentOrientation = Orientation.Right;
                    break;
                case Orientation.Down:
                    CurrentOrientation = Orientation.Left;
                    break;

            }
        }

        private void ProcessForward()
        {
            switch (CurrentOrientation)
            {
                case Orientation.Left:
                    XCordinate--;
                    break;
                case Orientation.Right:
                    XCordinate++;
                    break;
                case Orientation.Up:
                    YCordinate++;
                    break;
                case Orientation.Down:
                    YCordinate--;
                    break;
            }

            validator.Validate(XCordinate, YCordinate);
            
        }
    }
}
