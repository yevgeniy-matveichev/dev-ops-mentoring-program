using Mentoring.DataAccess;
using Mentoring.Shapes;
using Mentoring.Shapes.Shapes;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Shapes
{
    public class CircleTest
    {
        [Theory]
        [InlineData(10.0, 314.15)]
        [InlineData(5.0, 78.54)]
        public void TestSquare(double radius, double expectedSquare)
        {           
            var circle = new Circle(radius, Units.Meter);
            Assert.Equal(expectedSquare, System.Math.Round(circle.GetSquare(),2));
        }

        [Theory]
        [InlineData(2.0, Units.Meter, 12.57)]
        [InlineData(200.0, Units.Centimeter, 12.57)]
        [InlineData(2000.0, Units.Millimeter, 12.57)]
        public void TestSquareWithUnits(double radius, Units unit, double expectedSquare)
        {         
            var circle = new Circle(ShapeHelper.ToMeters(Units.Meter, radius), unit);
            Assert.Equal(unit, circle.Unit);
            Assert.Equal(expectedSquare, System.Math.Round(circle.GetSquare(), 2));            
        }

        [Theory]
        [InlineData(2.0, Units.Meter, 12.57)]
        [InlineData(200.0, Units.Centimeter, 12.57)]
        [InlineData(2000.0, Units.Millimeter, 12.57)]
        public void TestPerimeterWithUnits(double radius, Units unit, double expectedPerimeter)
        {
            var circle = new Circle(ShapeHelper.ToMeters(Units.Meter,radius), unit);
            Assert.Equal(unit, circle.Unit);
            Assert.Equal(expectedPerimeter, System.Math.Round(circle.GetPerimeter(),2));
        }
    }
}
