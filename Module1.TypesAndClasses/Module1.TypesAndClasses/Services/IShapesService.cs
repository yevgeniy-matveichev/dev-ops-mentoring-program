using Mentoring.Shapes.Interfaces;
using System.Threading.Tasks;

namespace Module1.TypesAndClasses.Services
{
    public interface IShapesService
    {
        string Name { get; }

        IShape ReadShapeExample();

        Task<IShape> ReadShapeExampleAsync();

        IShape ReadShape(string shapeFilePath);

        Task<IShape> ReadShapeAsync(string shapeFilePath);

        void WriteShape(string shapeFilePath, IShape shape);

        Task WriteShapeAsync(string shapeFilePath, IShape shape);
    }
}
