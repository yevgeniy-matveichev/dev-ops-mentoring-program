using Castle.DynamicProxy.Generators;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;
using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using Module1.TypesAndClasses.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace Module1.TypesAndClasses.Tests
{
    public class ShapeXUnitAlex
    {
        private List<IShape> _shapes;

        public ShapeXUnitAlex()
        {
            _shapes = new List<IShape>
            {
                new Ellipse(2, 2, Units.meters),
                new Ellipse(2, 3, Units.centimeters),
                new Ellipse(4, 2, Units.millimeters),
                new EquilateralTriangle(5, Units.meters),
                new EquilateralTriangle(7, Units.centimeters),
                new EquilateralTriangle(9, Units.millimeters),
                new Rectangle(4, 8, Units.meters),
                new Rectangle(7, 4, Units.centimeters),
                new Rectangle(4, 1, Units.millimeters),
                new Circle(2, Units.meters),
                new Circle(5, Units.centimeters),
                new Circle(1, Units.millimeters)
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
            var circle = _shapes.Where(shape => shape.Square() >= 1 && shape.Units.Equals(Units.meters) && shape.ShapeName.Equals(ShapeType.Circle))
                                .Max();
            Assert.IsType(circle.GetType(), typeof(Circle));
            Assert.True(circle.Square() >= 1 && circle.Units.Equals(Units.meters));
        }

        [Fact]
        public void TestRectanglePerimeter()
        {
            //    Выбрать Rectangle с наименьшим периметром(no exceptions).  
            var rect = _shapes.Where(shape => shape.ShapeName.Equals(ShapeType.Rectangle))
                                .OrderBy(shape => shape.Perimeter())
                                .FirstOrDefault();
            Assert.IsType(rect.GetType(), typeof(Rectangle));
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
            var selectSquare = _shapes.OrderBy(shape => shape.Square())
                                        .Select(shape => shape.Square());
            var maxSquare = _shapes.Max(shape => shape.Square());
            Assert.Equal(maxSquare, selectSquare.First());
        }

        [Fact]
        public void TestSquareSelectMany()
        {
            //    Выбрать числовые значения всех пощадей, отфильтрованных по возрастанию, с учетом единиц измерения.
            //    При помощи SelectMany
            //var selectManySquare = _shapes.SelectMany(shape => shape.Units, shape => shape.Square()).OrderBy(shape => shape.Square());
                                        
            //var maxSquare = _shapes.Max(shape => shape.Square());
            //Assert.Equal(maxSquare, selectManySquare.First());
        }
    }
}
