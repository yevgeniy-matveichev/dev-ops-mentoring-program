using Mentoring.Shapes.Interfaces;

namespace Module1.TypesAndClasses.Services
{
    public interface IShapesService
    {
        IShape ReadShapeExample();

        IShape ReadShape(string shapeFilePath);

        void WriteShape(string shapeFilePath, IShape shape);
    }

}
