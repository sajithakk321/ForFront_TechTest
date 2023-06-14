using System;

namespace SpiderRobotBAL.Common
{
    public class SpiderRobotValidator : IValidator<SpiderRobo>
    {
        private int xWall { get; }
        private int yWall { get; }
        public SpiderRobotValidator(int x, int y)
        {
            xWall = x;
            yWall = y;
        }

        public bool Validate(int xSpider, int ySpider)
        {

            if (xSpider > xWall || ySpider > yWall)
            {
                throw new Exception("Spider crossed the boundary. Please recheck the input given to spider.");
            }

            return true;
        }
    }
}
