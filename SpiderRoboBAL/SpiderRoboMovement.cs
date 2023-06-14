using SpiderRobotBAL.Common;
using System;
using System.Linq;

namespace SpiderRobotBAL
{
    public class SpiderRoboMovement : IMovementProcessor
    {
        private Wall wall { get; set; }
        private SpiderRobo spiderRobot { get; set; }
        private SpiderRobotValidator spiderRobotValidator;

        public SpiderRoboMovement(string wallSize, string spiderRoboPosition)
        {
            InitializeWall(wallSize);
            InitializeSpiderValidator(wall.XCordinate, wall.YCordinate);
            InitializeSpiderRobo(spiderRoboPosition, spiderRobotValidator);
        }

        private void InitializeSpiderValidator(int xCordinate, int yCordinate)
        {
            spiderRobotValidator = new SpiderRobotValidator(xCordinate, yCordinate);
        }

        private void InitializeWall(string wallSize)
        {
            string[] positions = wallSize.Split(' ');
            wall = new Wall(Int32.Parse(positions[0]), Int32.Parse(positions[1]));
        }
        private void InitializeSpiderRobo(string spiderRoboPosition, SpiderRobotValidator spiderRobotValidator)
        {
            string[] positions = spiderRoboPosition.Trim().Split(' ');
            spiderRobot = new SpiderRobo(Int32.Parse(positions[0]), Int32.Parse(positions[1]), positions[2].ToUpper(), spiderRobotValidator);
        }

        public string[] ProcessAction(string moveInstruction)
        {
            string[] finalPosition = new string[4];
            try
            {
                int length = moveInstruction.Count();
                for (int i = 0; i < length; i++)
                {
                    spiderRobot.ProcessInput(moveInstruction.ToUpper()[i]);
                }

                finalPosition[0] = "Success";
                finalPosition[1] = spiderRobot.XCordinate.ToString();
                finalPosition[2] = spiderRobot.YCordinate.ToString();
                finalPosition[3] = spiderRobot.CurrentOrientation.ToString();

            }
            catch (Exception exception)
            {
                finalPosition[0] = "Fail";
                finalPosition[1] = exception.Message;
                return finalPosition;
            }
            finally
            {

            }
            return finalPosition;

        }

    }
}
