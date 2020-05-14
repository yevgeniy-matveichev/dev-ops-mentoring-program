using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Shapes
{
    public class RectangleTest
    {
        [Theory]
        [InlineData(10.0, 20.0, 200.0)]
        [InlineData(5.0, 20.0, 100.0)]
        public void TestSquare(double a, double b, double expectedSquare)
        {
            // todo: remove this after the Rectangle supports doubles
            int roundA = (int)a;
            int roundB = (int)b;

            var rect = new Rectangle(roundA, roundB, Units.Meters);
            Assert.Equal(expectedSquare, rect.Square());
        }

        [Theory]
        [InlineData(2.0, 2.0, Units.Meters, 4.0)]
        [InlineData(2.0, 2.0, Units.Centimeters, 4.0)]
        [InlineData(2.0, 2.0, Units.Millimeters, 4.0)]
        public void TestSquareWithUnits(double a, double b, Units unit, double expectedSquare)
        {
            // todo: remove this after the Rectangle supports doubles
            int roundA = (int)a;
            int roundB = (int)b;

            var rect = new Rectangle(roundA, roundB, unit);
            Assert.Equal(unit, rect.Unit);
            Assert.Equal(expectedSquare, rect.Square());            
        }

        [Theory]
        [InlineData(2.0, 2.0, Units.Meters, 8.0)]
        [InlineData(2.0, 2.0, Units.Centimeters, 8.0)]
        [InlineData(2.0, 2.0, Units.Millimeters, 8.0)]
        public void TestPerimeterWithUnits(double a, double b, Units unit, double expectedPerimeter)
        {
            // todo: remove this after the Rectangle supports doubles
            int roundA = (int)a;
            int roundB = (int)b;

            var rect = new Rectangle(roundA, roundB, unit);
            Assert.Equal(unit, rect.Unit);
            Assert.Equal(expectedPerimeter, rect.Perimeter());
        }
    }
}
