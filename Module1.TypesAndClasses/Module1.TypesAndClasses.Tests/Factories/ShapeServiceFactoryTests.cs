using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Factories;
using Module1.TypesAndClasses.Services;
using System;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Factories
{
    public class ShapeServiceFactoryTests
    {
        private readonly ShapeServiceFactory _shapeServiceFactory = new ShapeServiceFactory();

        [Theory]
        [InlineData(ShapeTypes.Circle, typeof(CircleService))]
        [InlineData(ShapeTypes.Ellipse, typeof(EllipseService))]
        [InlineData(ShapeTypes.EquilateralTriangle, typeof(TriangleService))]
        [InlineData(ShapeTypes.Rectangle, typeof(RectangleService))]
        public void ShapeServiceFactory_Create(ShapeTypes type, Type t)
        {
            IShapesService service = _shapeServiceFactory.Create(type);
            Assert.IsType(t, service);
        }

        [Fact]
        public void ShapeServiceFactory_Throws()
        {
            Assert.Throws<ArgumentException>(() => _shapeServiceFactory.Create(ShapeTypes.None));
        }
    }
}