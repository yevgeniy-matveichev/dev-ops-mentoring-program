using Mentoring.DataAccess.ShapesRepository;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using System;

namespace Module1.TypesAndClasses.Services
{
    public class RectangleService : IShapesService
    {
        private ShapesRepository<RectangleModel> _repository;

        public string Name => nameof(RectangleService);

        public RectangleService(ShapesRepository<RectangleModel> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #region Public methods

        public IShape ReadShape(string shapeFilePath) => Convert(_repository.ReadShape(shapeFilePath));

        public IShape ReadShapeExample() => Convert(_repository.ReadShapeExample("rectangle.json"));

        public void WriteShape(string shapeFilePath, IShape shape)
        {
            throw new NotImplementedException();
        }

        #endregion

        private static IShape Convert(RectangleModel rectangleModel) => new Rectangle(rectangleModel.SideA, rectangleModel.SideB, rectangleModel.Unit);
    }
}
