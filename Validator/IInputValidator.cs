namespace ConsoleApp1.Validator
{
    public interface IInputValidator
    {
        bool ValidateInstruction(string moveInstruction);
        bool ValidateSpiderInput(string spiderPosition);
        bool ValidateWallInput(string wallTopOrientation);
    }
}