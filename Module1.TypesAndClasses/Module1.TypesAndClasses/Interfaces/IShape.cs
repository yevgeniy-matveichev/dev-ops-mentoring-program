namespace Module1.TypesAndClasses.Interfaces
{
    public enum Units
    {
        meters,
        centimeters,
        millimeters
    }
    public enum ShapeType
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
        
        ShapeType ShapeName { get; }
    }
}
