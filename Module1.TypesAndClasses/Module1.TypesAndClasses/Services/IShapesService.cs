using Mentoring.Shapes.Interfaces;

namespace Module1.TypesAndClasses.Services
{
    public interface IShapesService
    {
        IShape ReadShapeExample(ShapeTypes shapetype);

        IShape ReadShape(string shapeFilePath, ShapeTypes shapetype);

        IShape WriteShape(string shapeFilePath, IShape shape);
    }

}
