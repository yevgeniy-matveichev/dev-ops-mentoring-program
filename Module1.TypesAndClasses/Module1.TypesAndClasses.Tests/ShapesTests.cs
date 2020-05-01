using Castle.DynamicProxy.Generators;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;
using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using Module1.TypesAndClasses.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Module1.TypesAndClasses.Tests
{
    public class ShapesTests : IDisposable
    {
        #region private fields
        private readonly Mock<IShape> _ellipse;
        private readonly Mock<IShape> _equilateralTriangle;
        private readonly Mock<IShape> _rectangle;
        private readonly Mock<IShape> _regularPolygon;

        #endregion

        //BaseShape.units _unitCm = BaseShape.units.cm;
        //Circle _circle = new Circle(1, _unitCm); 
        //Why Error CS0236  A field initializer cannot reference the non-static field, method, or property 'ShapesTests._unitCm'

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
                new Ellipse(2,2),
                new EquilateralTriangle(5),
                //new Rectangle(4,4)
            };


            foreach (var shape in shapes)
            {
                Assert.Equal($"Shape: '{shape.GetType().Name}'. Square = {shape.Square()}, perimeter = {shape.Perimeter()}", shape.ToString());
            }
        }

        //[Fact]
        //public void TestCircleToString()
        //{
        //    //Circle _circle = new Circle(1, _unitCm);
        //    Assert.Equal($"Shape: '{_circle.GetType().Name}'. Square = {_circle.Square()}, perimeter = {_circle.Perimeter()}, radius = {_circle._radius}", _circle.ToString());
        //}

        [Fact]
        public void TestShapesEquals()
        {
            //Circle circle = new Circle(1, _unitCm);
            //Circle circleDuplicate1 = circle;
           // Circle circleDuplicate2 = new Circle(2, _unitCm);
            var elipse1 = new Ellipse(3, 4);
            var elipse2 = new Ellipse(8, 10);
            
            var triangle = new EquilateralTriangle(5);

            // Equals - by perimeter
            //Assert.True(circle.Equals(circleDuplicate1));
            //Assert.False(circle.Equals(circleDuplicate2));
            //Assert.Throws<System.InvalidCastException>(() => circle.Equals(elipse2));
            //Assert.True(new Rectangle(4, 4).Equals(new Rectangle(2, 6)));
            //Assert.False(new Rectangle(5, 5).Equals(new Rectangle(2, 6)));
            Assert.True(triangle.Equals(_ellipse.Object));
            Assert.False(triangle.Equals(_regularPolygon.Object));
            Assert.True(new Ellipse(5, 6).Equals(new Ellipse(6, 5)));
            Assert.False(new Ellipse(5, 1).Equals(new Ellipse(6, 5)));


            // == - by square            
            //Assert.False(elipse2 == circle);
            //Assert.True(circle == circleDuplicate1);
            //Assert.False(circle == circleDuplicate2);                   
            Assert.True(triangle == _regularPolygon.Object);
            Assert.False(triangle == _rectangle.Object);
            //Assert.True(new Rectangle(4, 4) == new Rectangle(2, 8));
            //Assert.False(new Rectangle(5, 5) == new Rectangle(2, 8));
            Assert.True(new Ellipse(5, 6) == new Ellipse(6, 5));
            Assert.False(new Ellipse(5, 1) == new Ellipse(6, 5));

            //!= - by square
            //Assert.False(circle != circleDuplicate1);
            //Assert.True(circle != circleDuplicate2);
            Assert.True(triangle != _rectangle.Object);
            Assert.False(triangle != _regularPolygon.Object);
            //Assert.False(new Rectangle(4, 4) != new Rectangle(2, 8));
            //Assert.True(new Rectangle(5, 5) != new Rectangle(2, 8));
            Assert.False(new Ellipse(5, 6) != new Ellipse(6, 5));
            Assert.False(new Ellipse(5, 1) != new Ellipse(6, 5));
        }
    }
}
