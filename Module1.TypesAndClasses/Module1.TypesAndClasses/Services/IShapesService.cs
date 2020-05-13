using Mentoring.Shapes.Interfaces;

namespace Module1.TypesAndClasses.Services
{
    public interface IShapesService
    {
        IShape ReadShape(ShapeType shapetype);
    }
}
