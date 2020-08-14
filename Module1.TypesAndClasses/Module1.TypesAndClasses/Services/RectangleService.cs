using Mentoring.DataAccess.Interfaces;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using System;
using System.Threading.Tasks;

namespace Module1.TypesAndClasses.Services
{
    public class RectangleService : IShapesService
    {
        private IShapeRepository<RectangleModel> _repository;

        public string Name => nameof(RectangleService);

        public RectangleService(IShapeRepository<RectangleModel> repository)
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

        #region async public methods

        public async Task<IShape> ReadShapeExampleAsync() => Convert(await _repository.ReadShapeExampleAsync("circle.json"));

        public async Task<IShape> ReadShapeAsync(string shapeFilePath) => Convert(await _repository.ReadShapeAsync(shapeFilePath));

        public async Task WriteShapeAsync(string shapeFilePath, IShape shape)
        {
            throw new NotImplementedException();
        }

        #endregion

        private static IShape Convert(RectangleModel rectangleModel) => new Rectangle(rectangleModel.SideA, rectangleModel.SideB, rectangleModel.Unit);
    }
}
