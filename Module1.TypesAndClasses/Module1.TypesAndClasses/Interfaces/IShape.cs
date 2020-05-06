namespace Module1.TypesAndClasses.Interfaces
{
    public enum Units
    {
        meters,
        centimeters,
        millimeters
    }
    public enum ShapeName
    {
        Circle,
        Ellipse,
        EquilateralTriangle,
        Rectangle
    }

    public interface IShape
    {
        double Square();

        double Perimeter();

        Units Units { get; }
        
        ShapeName ShapeName { get; }
    }
}
