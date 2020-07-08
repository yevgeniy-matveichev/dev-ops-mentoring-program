using Mentoring.DataAccess.ShapesRepository;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using System;

namespace Module1.TypesAndClasses.Services
{
    public class EllipseService : IShapesService
    {
        private ShapesRepository<EllipseModel> _repository;

        public string Name => nameof(EllipseService);

        public EllipseService(ShapesRepository<EllipseModel> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #region Public methods
        public IShape ReadShape(string shapeFilePath) => Convert(_repository.ReadShape(shapeFilePath));

        public IShape ReadShapeExample() => Convert(_repository.ReadShapeExample("ellipse.json"));

        public void WriteShape(string shapeFilePath, IShape shape)
        {
            throw new NotImplementedException();
        }

        #endregion

        private static IShape Convert(EllipseModel ellipseModel) => new Ellipse(ellipseModel.Radius1, ellipseModel.Radius2, ellipseModel.Unit);
    }
}
