using System.Collections.Generic;
using Xunit;
using System.Linq;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;

namespace Module1.TypesAndClasses.Tests.Linq
{
    public class ShapeXUnitAlex
    {
        private List<IShape> _shapes;

        public ShapeXUnitAlex()
        {
            _shapes = new List<IShape>
            {
                new Ellipse(2, 2, Units.Meter),
                new Ellipse(2, 3, Units.Centimeter),
                new Ellipse(4, 2, Units.Millimeter),
                new EquilateralTriangle(5, Units.Meter),
                new EquilateralTriangle(7, Units.Centimeter),
                new EquilateralTriangle(9, Units.Millimeter),
                new Rectangle(4, 8, Units.Meter),
                new Rectangle(7, 4, Units.Centimeter),
                new Rectangle(4, 1, Units.Millimeter),
                new Circle(2, Units.Meter),
                new Circle(5, Units.Centimeter),
                new Circle(1, Units.Millimeter)
            };
        }

        [Fact]
        public void TestPerimeter()
        {
            //    Выбрать единственный элемент с заданным периметром(Exception, если не существует). 
            var selectedShape = _shapes.Single(shape => shape.GetPerimeter() == 24);
            Assert.Equal(24, selectedShape.GetPerimeter());
        }

        [Fact]
        public void TestCircleSquare()
        {
            //    Выбрать Circle с наибольшей площадью, при этом площадь должна быть не менее 1 квадратного метра(Exception, если такой Circle в списке отсутствует). 
            Circle circle = (Circle)_shapes.Where(shape => shape.GetSquare() >= 1 && shape.Unit.Equals(Units.Meter) && shape.shapeType.Equals(ShapeTypes.Circle))
                            .Max();
            
            Assert.True(circle.GetSquare() >= 1 && circle.Unit.Equals(Units.Meter));
        }

        [Fact]
        public void TestRectanglePerimeter()
        {
            //    Выбрать Rectangle с наименьшим периметром(no exceptions).  
            Rectangle rect = (Rectangle)_shapes.Where(shape => shape.shapeType.Equals(ShapeTypes.Rectangle))
                                .OrderBy(shape => shape.GetPerimeter())
                                .FirstOrDefault();

            Assert.True(rect.GetPerimeter() > 0);
        }

        [Fact]
        public void TestType()
        {
            //    Отфильтровать список  по типу: выбрать только фигуры типа Rectangle и Circle(оба типа в одном). 
            var figures = _shapes.Where(shape => shape.shapeType.Equals(ShapeTypes.Rectangle) || shape.shapeType.Equals(ShapeTypes.Circle));
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
            var maxSquare = _shapes.OrderBy(shape => shape.GetSquare())
                                   .Select(shape => shape.GetSquare())
                                   .Max(square => square);

            var maxSquare2 = _shapes
                                    .Select(shape => shape.GetSquare())
                                    .OrderBy(shape => shape)                                   
                                    .Max(square => square);

            // todo:
            // Assert.Equal(_shapes.First().GetSquare(), maxSquare);
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