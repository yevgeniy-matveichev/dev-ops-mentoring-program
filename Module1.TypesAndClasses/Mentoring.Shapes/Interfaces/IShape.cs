using Mentoring.DataModel;

namespace Mentoring.Shapes.Interfaces
{
  

    // cr: ShapeType => ShapeTypes, please. Enum names are usually plurual, enum members - singular
    public enum ShapeTypes
    {
        Circle,
        Ellipse,
        EquilateralTriangle,
        Rectangle
    }

    public interface IShape
    {
        // cr: let's rename the methods to GetSquare(), GetPerimeter, because currently they sound like props.
        double GetSquare();

        double GetPerimeter();

        Units Unit { get; }
        
        ShapeTypes shapeType { get; } // cr: ShapeType shapeType => ShapeTypes ShapeType, please
    }
}
