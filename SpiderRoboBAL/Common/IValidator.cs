namespace SpiderRobotBAL.Common
{
    public interface IValidator<T>
    {
        bool Validate(int xSpider, int ySpider);
    }
}
