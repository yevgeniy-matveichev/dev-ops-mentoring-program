using Mentoring.DataAccess.ShapesRepository;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Services
{
    public class CircleService : IShapesService
    {
        private ShapesRepository<CircleModel> _repository;

        #region Constructor

        public CircleService()
        {
            _repository = new ShapesRepository<CircleModel>();
        }

        #endregion

        #region Public methods
        public IShape ReadShape(string shapeFilePath) => Convert(_repository.ReadShape(shapeFilePath));

        public IShape ReadShapeExample() => Convert(_repository.ReadShapeExample("circle.json"));

        public void WriteShape(string shapeFilePath, IShape shape)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private methods

        private static IShape Convert(CircleModel circleModel) => new Circle(circleModel.Radius, circleModel.Unit);

        #endregion
    }
}
