using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace Module1.TypesAndClasses.Tests.Linq
{
    public class ShapeXUnitAlex
    {
        private List<IShape> _shapes;

        public ShapeXUnitAlex()
        {
            _shapes = new List<IShape>
            {
                new Ellipse(2, 2, Units.Meters),
                new Ellipse(2, 3, Units.Centimeters),
                new Ellipse(4, 2, Units.Millimeters),
                new EquilateralTriangle(5, Units.Meters),
                new EquilateralTriangle(7, Units.Centimeters),
                new EquilateralTriangle(9, Units.Millimeters),
                new Rectangle(4, 8, Units.Meters),
                new Rectangle(7, 4, Units.Centimeters),
                new Rectangle(4, 1, Units.Millimeters),
                new Circle(2, Units.Meters),
                new Circle(5, Units.Centimeters),
                new Circle(1, Units.Millimeters)
            };
        }

        [Fact]
        public void TestPerimeter()
        {
            //    Выбрать единственный элемент с заданным периметром(Exception, если не существует). 
            var selectedShape = _shapes.Single(shape => shape.Perimeter() == 24);
            Assert.Equal(24, selectedShape.Perimeter());
        }

        [Fact]
        public void TestCircleSquare()
        {
            //    Выбрать Circle с наибольшей площадью, при этом площадь должна быть не менее 1 квадратного метра(Exception, если такой Circle в списке отсутствует). 
            Circle circle = (Circle)_shapes.Where(shape => shape.Square() >= 1 && shape.Unit.Equals(Units.Meters) && shape.ShapeName.Equals(ShapeType.Circle))
                            .Max();
            
            Assert.True(circle.Square() >= 1 && circle.Unit.Equals(Units.Meters));
        }

        [Fact]
        public void TestRectanglePerimeter()
        {
            //    Выбрать Rectangle с наименьшим периметром(no exceptions).  
            Rectangle rect = (Rectangle)_shapes.Where(shape => shape.ShapeName.Equals(ShapeType.Rectangle))
                                .OrderBy(shape => shape.Perimeter())
                                .FirstOrDefault();

            Assert.True(rect.Perimeter() > 0);
        }

        [Fact]
        public void TestType()
        {
            //    Отфильтровать список  по типу: выбрать только фигуры типа Rectangle и Circle(оба типа в одном). 
            var figures = _shapes.Where(shape => shape.ShapeName.Equals(ShapeType.Rectangle) || shape.ShapeName.Equals(ShapeType.Circle));
            foreach (var figure in figures)
            {
                Assert.True(figure.GetType() == typeof(Circle) || figure.GetType() == typeof(Rectangle));
            }
        }

        [Fact]
        public void TestSquareSelect()
        {
            //    Выбрать числовые значения всех пощадей, отфильтрованных по возрастанию, с учетом единиц измерения.
            //    При помощи Select
            var maxSquare = _shapes.OrderBy(shape => shape.Square())
                                   .Select(shape => shape.Square())
                                   .Max(square => square);

            var maxSquare2 = _shapes
                                    .Select(shape => shape.Square())
                                    .OrderBy(shape => shape)                                   
                                    .Max(square => square);

            // todo:
            // Assert.Equal(_shapes.First().Square(), maxSquare);
        }

        [Fact]
        public void TestSquareSelectMany()
        {
            //    Выбрать числовые значения всех пощадей, отфильтрованных по возрастанию, с учетом единиц измерения.
            //    При помощи SelectMany
            //    todo:
        }
    }
}