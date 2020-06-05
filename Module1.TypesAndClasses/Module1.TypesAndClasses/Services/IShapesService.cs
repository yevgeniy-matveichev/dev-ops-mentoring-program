using Mentoring.Shapes.Interfaces;

namespace Module1.TypesAndClasses.Services
{
    public interface IShapesService
    {
        IShape ReadShapeExample(ShapeTypes shapetype);

        IShape ReadShape(string shapeFilePath, ShapeTypes shapetype);

        void WriteShape(string shapeFilePath, ShapeTypes shapetype);
    }

}
