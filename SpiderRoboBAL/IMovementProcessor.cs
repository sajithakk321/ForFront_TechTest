namespace SpiderRobotBAL
{
    public interface IMovementProcessor
    {
        string[] ProcessAction(string moveInstruction);
    }
}