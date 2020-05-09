using System;
using System.Collections.Generic;
using System.Text;
using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using Module1.TypesAndClasses.Extensions;
using Moq;
using Xunit;
using System.Linq;


namespace Module1.TypesAndClasses.Tests
{

    public class ShapesLinqTests
    {
        private List<IShape> shapes = new List<IShape>
            {
                new Circle(2,Units.meters),
                new EquilateralTriangle(5),
                new Rectangle(4,4, Units.meters),
                new Rectangle(40,50, Units.centimeters),
                new Rectangle(600,400, Units.centimeters),
                new Rectangle(400,200, Units.centimeters),
                new Rectangle(4000,8000, Units.millimeters)
            };


        [Fact]
        public void TestLinq()
        {
            Assert.True((new Rectangle(4, 4, Units.meters)).ShapeName == ShapeType.Rectangle);
            var ShapeRectangle = shapes.Single(shape => shape.ShapeName == ShapeType.Rectangle);
            Assert.True(ShapeRectangle.ShapeName == ShapeType.Rectangle);
        }
        [Fact]
        // Test to Find the shape with known Perimeter
        public void TestPerimeter()
        {

            var shapePerimeter = shapes.Single(shape => shape.Perimeter() == 12);
            Assert.True(shapePerimeter.Perimeter() == 12);
        }

        // Test to Find Circle Shape with the biggest Square
        [Fact]
        public void TestCircleSquare()
        {
            var shapeSquareCircle = shapes.OfType<Circle>().Where(shape => shape.Square() > 1).OrderByDescending(shape => shape.Square()).First();
            Assert.True(shapeSquareCircle.Square() == new Circle(2, Units.meters).Square());
        }

        // Test to find Rectangle with the minimum Perimeter with no exceptions
        [Fact]
        public void TestPerimeterRectangle()
        { 
             var shapePerimeterRectangle = shapes.OfType<Rectangle>().OrderBy(shape => shape.Perimeter()).FirstOrDefault();
             Assert.True(shapePerimeterRectangle.Perimeter() == new Rectangle(40, 50, Units.centimeters).Perimeter());
             Assert.True(shapePerimeterRectangle != null);
        }

        // Test to Select List of Rectangle and Circle
        [Fact]
        public void TestRectangleAndCircle()
        {
            List<IShape> shapeRectangleAndCircle = shapes.Where(shape => shape.ShapeName == ShapeType.Rectangle || shape.ShapeName == ShapeType.Circle).ToList();
            Assert.True(shapeRectangleAndCircle[1] == shapes[2]);
        }

        // Test Filter with Perimeters
        [Fact]
        public void TestSelectPerimeter()
        { 
            var perimeterList = shapes.Select(shape => shape.Perimeter()).OrderBy(shape => shape).ToList();
            Assert.True(perimeterList[1] == 12);
            Assert.False(perimeterList[1] == 13);
         }
    }
}
