using Mentoring.DataAccess.Interfaces;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using System;

namespace Module1.TypesAndClasses.Services
{
    public class TriangleService : IShapesService
    {
        private IShapeRepository<EquilateralTriangleModel> _repository;

        public string Name => nameof(TriangleService);

        public TriangleService(IShapeRepository<EquilateralTriangleModel> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #region Public methods

        public IShape ReadShape(string shapeFilePath) => Convert(_repository.ReadShape(shapeFilePath));

        public IShape ReadShapeExample() => Convert(_repository.ReadShapeExample("equilateraltriangle.json"));

        public void WriteShape(string shapeFilePath, IShape shape)
        {
            throw new NotImplementedException();
        }

        #endregion

        private static IShape Convert(EquilateralTriangleModel EquilateralTriangleModel) => new EquilateralTriangle(EquilateralTriangleModel.Side, EquilateralTriangleModel.Unit);
    }
}
