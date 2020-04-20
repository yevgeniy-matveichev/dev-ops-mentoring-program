using Castle.DynamicProxy.Generators;
using Module1.TypesAndClasses.Helpers;
using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using static Module1.TypesAndClasses.Shapes.BaseShape.MetricName;


namespace Module1.TypesAndClasses.Tests
{
    public class ShapesTests : IDisposable
    {
        #region private fields

        private readonly Circle _circle = new Circle(1);
        private readonly Mock<IShape> _ellipse;
        private readonly Mock<IShape> _equilateralTriangle;
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
            var shapes = new List<BaseShape>
            {
             //   new Circle(1),
              //  new Ellipse(2,2),
               // new EquilateralTriangle(),
                new Rectangle(4,4,m)
            };


            foreach (var shape in shapes)
            {
                Assert.Equal($"Shape: '{shape.ShapeName()}'. Square = {shape.Square()} {shape.Metric()}2, perimeter = {shape.Perimeter()} {shape.Metric()}", shape.ToString());
            }
        }

        [Fact]
        public void TestShapesEquals()
        {
            Circle circleDuplicate1 = _circle;
            Circle circleDuplicate2 = new Circle(2);
            var elipse1 = new Ellipse(3, 4);
            var elipse2 = new Ellipse(8, 10);
            var triangle = new EquilateralTriangle();

            // Equals - by perimeter
            Assert.True(_circle.Equals(circleDuplicate1));
            Assert.False(_circle.Equals(circleDuplicate2));
            Assert.Throws<System.InvalidCastException>(() => _circle.Equals(elipse2));
            Assert.True(new Rectangle(4, 4,m).Equals(new Rectangle(2, 6,m)));
            Assert.False(new Rectangle(3, 4,m).Equals(new Rectangle(2, 6,m)));
            Assert.True(triangle.Equals(_ellipse.Object));
         
            // == - by square            
            Assert.False(elipse2 == _circle);
            Assert.True(_circle == circleDuplicate1);
            Assert.False(_circle == circleDuplicate2);                   
            Assert.True(triangle == _regularPolygon.Object);
            Assert.True(new Rectangle(4, 4, m) == new Rectangle(2, 8, m));
            Assert.False(new Rectangle(4, 4, m) != new Rectangle(2, 8, m));
          //      # Helpers 
            Assert.True(ShapeHelper.PerimeterEquals(new Rectangle(4, 4, m), new Rectangle(2, 6, m)));
            Assert.False(ShapeHelper.SquareEquals(new Rectangle(4, 4, m), new Rectangle(2, 8, m)));
        }
    }
}
