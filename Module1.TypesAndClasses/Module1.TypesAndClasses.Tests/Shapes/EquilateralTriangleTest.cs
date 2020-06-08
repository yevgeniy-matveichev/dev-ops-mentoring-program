using Mentoring.DataAccess;
using Mentoring.Shapes.Shapes;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Shapes
{
    public class EquilateralTriangleTest
    {
        [Theory]
        [InlineData(2.1, Units.Meter, 1.9095860153446871)]
        [InlineData(3.4, Units.Centimeter, 0.0005005626833874056)]
        [InlineData(5.3, Units.Millimeter, 1.216332679615244E-05)]
        public void TestSquare(double a, Units unit, double expectedSquare)
        {
            var triangle = new EquilateralTriangle(a, unit);
            Assert.Equal(unit, triangle.Unit);
            Assert.Equal(expectedSquare, triangle.GetSquare());
        }

        [Theory]
        [InlineData(2.1, Units.Meter, 6.3000000000000007)]
        [InlineData(3.4, Units.Centimeter, 0.10200000000000001)]
        [InlineData(5.3, Units.Millimeter, 0.0159)]
        public void TestPerimeter(double a, Units unit, double expectedPerimeter)
        {
            var triangle = new EquilateralTriangle(a, unit);
            Assert.Equal(unit, triangle.Unit);
            Assert.Equal(expectedPerimeter, triangle.GetPerimeter());
        }
    }
}
