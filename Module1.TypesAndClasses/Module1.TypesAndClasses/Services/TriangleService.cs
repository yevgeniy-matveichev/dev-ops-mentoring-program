using Mentoring.DataAccess.ShapesRepository;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Services
{
    class TriangleService : IShapesService
    {
        #region Private Fields

        private ShapesRepository<EquilateralTriangleModel> _repository;

        #endregion

        #region Constructor

        public TriangleService()
        {
            _repository = new ShapesRepository<EquilateralTriangleModel>();
        }

        #endregion

        #region Public methods

        public IShape ReadShape(string shapeFilePath) => Convert(_repository.ReadShape(shapeFilePath));

        public IShape ReadShapeExample() => Convert(_repository.ReadShapeExample("equilateraltrianglemodel.json"));

        public void WriteShape(string shapeFilePath, IShape shape)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private methods
        private static IShape Convert(EquilateralTriangleModel EquilateralTriangleModel) => new EquilateralTriangle(EquilateralTriangleModel.Side, EquilateralTriangleModel.Unit);

        #endregion
    }
}
