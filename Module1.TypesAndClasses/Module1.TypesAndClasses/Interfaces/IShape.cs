namespace Module1.TypesAndClasses.Interfaces
{
    public enum Units
    {
        meter,
        centimeter,
        millimeter
    }

    public interface IShape
    {
        double Square();

        double Perimeter();

        Units Units { get; }
    }
}
