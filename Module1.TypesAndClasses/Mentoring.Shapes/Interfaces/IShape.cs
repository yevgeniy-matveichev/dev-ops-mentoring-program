namespace Mentoring.Shapes.Interfaces
{
    public enum Units
    {
        Meters,
        Centimeters,
        Millimeters
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

        Units Unit { get; }
        
        ShapeType ShapeName { get; }
    }
}
