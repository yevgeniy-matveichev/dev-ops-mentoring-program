
namespace Module1.TypesAndClasses.Interfaces
{
    public enum Metric
    {
        Milimetr,
        Decimetr,
        Santimetr,
        Metr,
        Kilometr
    }

    public interface IShape
    {
        double Square();

        double Perimeter();

        Metric Metric { get; }
    }
}
