using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiderRobotBAL;
using SpiderRobotBAL.Common;
using System;

namespace UnitTestProjectSpiderRoboBAL
{
    [TestClass]


    public class UnitTestSpiderRoboBAL
    {
        [TestMethod]
        [DataRow("5 17", "4 10 Left", "FLFLFRFFLF")]
        public void TestRunSuccess_ProcessAction(string wallSize, string spiderPosition, string moveInstruction)
        {
            //Arrange
            string expectedPosition = "Success 5 7 Right";
            string[] wallSpec = wallSize.Split(' ');
            Wall wall = new Wall(Int32.Parse(wallSpec[0]), Int32.Parse(wallSpec[1]));
            string[] spiderPositions = spiderPosition.Trim().Split(' ');
            SpiderRobotValidator spiderRobotValidator = new SpiderRobotValidator(Int32.Parse(spiderPositions[0]), Int32.Parse(spiderPositions[1]));
            SpiderRobo spiderRobot = new SpiderRobo(Int32.Parse(spiderPositions[0]),
               Int32.Parse(spiderPositions[1]), spiderPositions[2].ToUpper(), spiderRobotValidator);

            IMovementProcessor objMovement = new SpiderRoboMovement(wallSize, spiderPosition);

            //Act

            string[] result = objMovement.ProcessAction(moveInstruction);
            string finalPosition = string.Join(" ", result);

            //Assert
            Assert.AreEqual(expectedPosition, finalPosition);

        }
    }
}
