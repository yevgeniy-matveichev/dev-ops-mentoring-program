using Mentoring.DataAccess;
using Mentoring.Shapes;
using Mentoring.Shapes.Shapes;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Shapes
{
    public class EllipseTest
    {
        [Theory]
        [InlineData(10.0, 10.0, 314.16)]
        [InlineData(3.0, 6.0, 56.55)]
        public void TestSquare(double radius1, double radius2, double expectedSquare)
        {           
            var ellipse = new Ellipse(radius1, radius2, Units.Meter);
            Assert.Equal(expectedSquare, System.Math.Round(ellipse.GetSquare(),2));
        }

        [Theory]
        [InlineData(3.0, 6.0, Units.Meter, 56.55)]
        [InlineData(300.0, 600.0, Units.Centimeter, 56.55)]
        [InlineData(3000.0, 6000.0, Units.Millimeter, 56.55)]
        public void TestSquareWithUnits(double radius1, double radius2, Units unit, double expectedSquare)
        {
            var ellipse = new Ellipse(ShapeHelper.ToMeters(Units.Meter, radius1), ShapeHelper.ToMeters(Units.Meter, radius2), unit);
            Assert.Equal(unit, ellipse.Unit);
            Assert.Equal(expectedSquare, System.Math.Round(ellipse.GetSquare(), 2));
        }

        [Theory]
        [InlineData(3.0, 6.0, Units.Meter, 29.80)]
        [InlineData(300.0, 600.0, Units.Centimeter, 29.80)]
        [InlineData(3000.0, 6000.0, Units.Millimeter, 29.80)]
        public void TestPerimeterWithUnits(double radius1, double radius2, Units unit, double expectedPerimeter)
        {
            var ellipse = new Ellipse(ShapeHelper.ToMeters(Units.Meter, radius1), ShapeHelper.ToMeters(Units.Meter, radius2), unit);
            Assert.Equal(unit, ellipse.Unit);
            Assert.Equal(expectedPerimeter, System.Math.Round(ellipse.GetPerimeter(), 2));
        }
    }
}
