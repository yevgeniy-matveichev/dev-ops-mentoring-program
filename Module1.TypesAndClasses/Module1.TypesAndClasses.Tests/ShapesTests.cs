using Castle.DynamicProxy.Generators;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;
using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Module1.TypesAndClasses.Tests
{
    public class ShapesTests : IDisposable
    {
        #region private fields
        BaseShape.units u = BaseShape.units.cm;
        private readonly Mock<IShape> _ellipse;
        private readonly Mock<IShape> _equilateralTriangle;
        private readonly Mock<IShape> _rectangle;
        private readonly Mock<IShape> _regularPolygon;

        #endregion

        #region constructor, disposing

        public ShapesTests()
        {
            _regularPolygon = new Mock<IShape>();
            _equilateralTriangle = new Mock<IShape>();
            _ellipse = new Mock<IShape>();
            _rectangle = new Mock<IShape>();

            // todo: remove after the methods are implemented
            _regularPolygon.Setup(c => c.Perimeter()).Returns(86);
            _regularPolygon.Setup(c => c.Square()).Returns(10);

            _equilateralTriangle.Setup(c => c.Perimeter()).Returns(10);
            _equilateralTriangle.Setup(c => c.Square()).Returns(100);

            _ellipse.Setup(c => c.Perimeter()).Returns(15);
            _ellipse.Setup(c => c.Square()).Returns(578);

            _rectangle.Setup(c => c.Perimeter()).Returns(342);
            _rectangle.Setup(c => c.Perimeter()).Returns(432);
        }

        public void Dispose()
        {

        }

        #endregion

        [Fact]
        public void TestShapesToString()
        {
            var shapes = new List<IShape>
            {
                new Circle(1, u),
                new Ellipse(2,2),
                new EquilateralTriangle(5),
                new Rectangle(4,4)
            };


            foreach (var shape in shapes)
            {
                Assert.Equal($"Shape: '{shape.GetType().Name}'. Square = {shape.Square()}, perimeter = {shape.Perimeter()}", shape.ToString());
            }
        }

        [Fact]
        public void TestShapesEquals()
        {
            Circle _circle = new Circle(1, u);
            Circle circleDuplicate1 = _circle;
            Circle circleDuplicate2 = new Circle(2, u);
            var elipse1 = new Ellipse(3, 4);
            var elipse2 = new Ellipse(8, 10);
            var triangle = new EquilateralTriangle(5);

            // Equals - by perimeter
            Assert.True(_circle.Equals(circleDuplicate1));
            Assert.False(_circle.Equals(circleDuplicate2));
            Assert.Throws<System.InvalidCastException>(() => _circle.Equals(elipse2));
            Assert.True(new Rectangle(4, 4).Equals(new Rectangle(2, 6)));
            Assert.False(new Rectangle(5, 5).Equals(new Rectangle(2, 6)));
            Assert.True(triangle.Equals(_ellipse.Object));
            Assert.False(triangle.Equals(_regularPolygon.Object));
            Assert.True(new Ellipse(5, 6).Equals(new Ellipse(6, 5)));
            Assert.False(new Ellipse(5, 1).Equals(new Ellipse(6, 5)));


            // == - by square            
            Assert.False(elipse2 == _circle);
            Assert.True(_circle == circleDuplicate1);
            Assert.False(_circle == circleDuplicate2);                   
            Assert.True(triangle == _regularPolygon.Object);
            Assert.False(triangle == _rectangle.Object);
            Assert.True(new Rectangle(4, 4) == new Rectangle(2, 8));
            Assert.False(new Rectangle(5, 5) == new Rectangle(2, 8));
            Assert.True(new Ellipse(5, 6) == new Ellipse(6, 5));
            Assert.False(new Ellipse(5, 1) == new Ellipse(6, 5));

            //!= - by square
            Assert.False(_circle != circleDuplicate1);
            Assert.True(_circle != circleDuplicate2);
            Assert.True(triangle != _rectangle.Object);
            Assert.False(triangle != _regularPolygon.Object);
            Assert.False(new Rectangle(4, 4) != new Rectangle(2, 8));
            Assert.True(new Rectangle(5, 5) != new Rectangle(2, 8));
            Assert.False(new Ellipse(5, 6) != new Ellipse(6, 5));
            Assert.False(new Ellipse(5, 1) != new Ellipse(6, 5));
        }
    }
}
