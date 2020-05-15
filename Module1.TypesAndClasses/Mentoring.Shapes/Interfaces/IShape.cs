namespace Mentoring.Shapes.Interfaces
{
    public enum Units
    {
        Meter,
        Centimeter,
        Millimeter
    }

    public enum ShapeTypes
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
        
        ShapeTypes shapeType { get; }
    }
}
