using Mentoring.Shapes.Interfaces;
using System;


namespace Module1.TypesAndClasses.Services
{
    public class ShapesService : IShapesService
    {
        private readonly IShapesService _repository;

        public ShapesService(ShapeTypes shapeType)
        {
            _repository = new ShapeServiceFactory().Create(shapeType);
    }
        
        public IShape ReadShape(string shapeFilePath) => _repository.ReadShape(shapeFilePath);

        public IShape ReadShapeExample() => _repository.ReadShapeExample();

        public void WriteShape(string shapeFilePath, IShape shape) => _repository.WriteShape(shapeFilePath, shape);
    }
}
