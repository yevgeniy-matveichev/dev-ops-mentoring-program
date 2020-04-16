using Castle.DynamicProxy.Generators;
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

        private readonly Circle _circle = new Circle(1);
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

            // todo: remove after the methods are implemented
            _regularPolygon.Setup(c => c.Perimeter()).Returns(86);
            _regularPolygon.Setup(c => c.Square()).Returns(100);

            _equilateralTriangle.Setup(c => c.Perimeter()).Returns(10);
            _equilateralTriangle.Setup(c => c.Square()).Returns(100);
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


                new Circle(1),
                new Ellipse(2,2)

                // todo: add all other shapes
            };


            foreach (var shape in shapes)
            {
                Assert.Equal($"Shape: '{shape.GetType().Name}'. Square = {shape.Square()}, perimeter = {shape.Perimeter()}", shape.ToString());
            }
        }

        [Fact]
        public void TestShapesEquals()
        {
            
            Circle circleDuplicate1 = _circle;
            Circle circleDuplicate2 = new Circle(2);

            var elipse1 = new Ellipse(3, 4);
            var elipse2 = new Ellipse(8, 10);

            // Equals - by perimeter
            Assert.True(_circle.Equals(circleDuplicate1));
            Assert.False(_circle.Equals(circleDuplicate2));
            Assert.Throws<System.InvalidCastException>(() => _circle.Equals(elipse2));

            //  Assert.True(elipse1.Equals(_circle));

            // *** KATE'S TESTS :) don't understand how to call my overrided methods :(
            //Assert.True(_equilateralTriangle.Object.Equals(_circle.Object.Perimeter()));
            //Assert.True(_equilateralTriangle.Object.Perimeter().Equals(_equilateralTriangle.Object.Perimeter()));
            //Assert.False(_equilateralTriangle.Object.Perimeter().Equals(_regularPolygon.Object.Perimeter()));

            //Assert.True(_regularPolygon.Object.Square() == _equilateralTriangle.Object.Square());
            //Assert.False(_circle.Object.Square() == _equilateralTriangle.Object.Square());
            //Assert.False(_circle.Object.Square() == _regularPolygon.Object.Square());
            // *** END OF KATE'S TEST :)

            // == - by square            
            Assert.False(elipse2 == _circle);

            Assert.True(_circle == circleDuplicate1);
            Assert.False(_circle == circleDuplicate2);
        }
    }
}
