using Mentoring.DataAccess;

namespace Mentoring.Shapes.Interfaces
{
    public enum ShapeTypes
    {
        None,
        Circle,
        Ellipse,
        EquilateralTriangle,
        Rectangle
    }

    public interface IShape
    {
        double GetSquare();

        double GetPerimeter();

        Units Unit { get; }
        
        ShapeTypes shapeType { get; }
    }
}
