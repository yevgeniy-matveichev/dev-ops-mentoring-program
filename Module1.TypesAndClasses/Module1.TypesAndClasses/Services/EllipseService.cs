using Mentoring.DataAccess.ShapesRepository;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Services
{
    class EllipseService : IShapesService
    {
        #region Private Fields

        private ShapesRepository<EllipseModel> _repository;

        #endregion

        #region Constructor

        public EllipseService()
        {
            _repository = new ShapesRepository<EllipseModel>();
        }

        #endregion

        #region Public methods
        public IShape ReadShape(string shapeFilePath) => Convert(_repository.ReadShape(shapeFilePath));

        public IShape ReadShapeExample() => Convert(_repository.ReadShapeExample("ellipse.json"));

        public void WriteShape(string shapeFilePath, IShape shape)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private methods
        private static IShape Convert(EllipseModel ellipseModel) => new Ellipse(ellipseModel.Radius1, ellipseModel.Radius2, ellipseModel.Unit);

        #endregion
    }
}
