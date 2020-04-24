namespace Module1.TypesAndClasses.Interfaces
{
    public enum Units
    {
        meters,
        centimeters,
        millimeters
    }

    public interface IShape
    {
        double Square();

        double Perimeter();

        Units Units { get; }
    }
}
