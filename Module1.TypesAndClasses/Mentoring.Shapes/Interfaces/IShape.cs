namespace Mentoring.Shapes.Interfaces
{
    public enum Units
    {
        // cr: rename all these values to singular, please. e.g. Meters => Meter (sorry, it was my mistake)
        Meters,
        Centimeters,
        Millimeters
    }

    // cr: ShapeType => ShapeTypes, please. Enum names are usually plurual, enum members - singular
    public enum ShapeType
    {
        Circle,
        Ellipse,
        EquilateralTriangle,
        Rectangle
    }

    public interface IShape
    {
        // cr: let's rename the methods to GetSquare(), GetPerimeter, because currently they sound like props.
        double Square();

        double Perimeter();

        Units Unit { get; }
        
        ShapeType shapeType { get; } // cr: ShapeType shapeType => ShapeTypes ShapeType, please
    }
}
