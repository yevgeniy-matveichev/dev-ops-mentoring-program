using Mentoring.DataAccess.Interfaces;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using System;

namespace Module1.TypesAndClasses.Services
{
    public class CircleService : IShapesService
    {
        private readonly IShapeRepository<CircleModel> _repository;

        public string Name => nameof(CircleService);

        public CircleService(IShapeRepository<CircleModel> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #region Public methods

        public IShape ReadShape(string shapeFilePath) => Convert(_repository.ReadShape(shapeFilePath));

        public IShape ReadShapeExample() => Convert(_repository.ReadShapeExample("circle.json"));

        public void WriteShape(string shapeFilePath, IShape shape)
        {
            throw new NotImplementedException();
        }

        #endregion

        private static IShape Convert(CircleModel circleModel) => new Circle(circleModel.Radius, circleModel.Unit);
    }
}
