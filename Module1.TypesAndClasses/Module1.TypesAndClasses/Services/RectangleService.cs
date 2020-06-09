using Mentoring.DataAccess.ShapesRepository;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using System;

namespace Module1.TypesAndClasses.Services
{
    class RectangleService : IShapesService
    {
        readonly ShapesRepository<RectangleModel> _repository;

        public RectangleService()
        {
            _repository = new ShapesRepository<RectangleModel>();
        }

        #region public methods

        public IShape ReadShape(string shapeFilePath) => Convert(_repository.ReadShape(shapeFilePath));

        public IShape ReadShapeExample() => Convert(_repository.ReadShapeExample("Rectangle.json"));

        public void WriteShape(string shapeFilePath, IShape shape)
        {
            var rectangle = (Rectangle)shape;

            _repository.WriteShape(shapeFilePath, Convert(rectangle));
        }

        #endregion

        private static RectangleModel Convert(Rectangle rectangle)
        {
            // 
            return null;
        }

        private static IShape Convert(RectangleModel rectangleModel) => new Rectangle(rectangleModel.SideA, rectangleModel.SideB, rectangleModel.Unit);
    }
}
