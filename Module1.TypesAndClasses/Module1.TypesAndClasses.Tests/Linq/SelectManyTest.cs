using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Linq
{
    public class SelectManyTest
    {
        private readonly List<ShapeContainer> _containers;

        public SelectManyTest()
        {
            _containers = new List<ShapeContainer>()
            {
                new ShapeContainer
                {
                    ContainerName = "Triangles",
                    Shapes = new List<IShape> {
                        new EquilateralTriangle(3, Units.Centimeters),
                        new EquilateralTriangle(7.8, Units.Millimeters),
                        new EquilateralTriangle(5, Units.Meters)
                    }
                },
                new ShapeContainer
                {
                    ContainerName = "Circles",
                    Shapes = new List<IShape> {
                        new Circle(5, Units.Meters),
                        new Circle(8, Units.Millimeters),
                        new Circle(2.6, Units.Centimeters)
                    }
                },
                new ShapeContainer
                {
                    ContainerName = "Ellipses",
                    Shapes = new List<IShape> {
                        new Ellipse(4, 6, Units.Millimeters),
                        new Ellipse(6, 9, Units.Centimeters),
                        new Ellipse(1, 2, Units.Meters)
                    }
                },
                new ShapeContainer
                {
                    ContainerName = "Rectangles",
                    Shapes = new List<IShape> {
                        new Rectangle(5, 8, Units.Centimeters),
                        new Rectangle(10, 24, Units.Millimeters),
                        new Rectangle(1, 2, Units.Meters)
                    }
                }
            };
        }

        [Fact]
        public void SelecMany_OrderByShape_Metrics()
        {
            /* e. Выбрать числовые значения всех пощадей, отфильтрованных по возрастанию, с учетом единиц измерения при помощи SelectMany */
            List<double> squares = _containers
                .SelectMany(container => container.Shapes) // flat list of containers
                .Select(shape => shape.Square())           // select squares
                .OrderBy(square => square)                 // ordering by square
                .ToList();                                 // real list instead of IQueryable

            Assert.Equal(12, squares.Count);
            Assert.True(squares.First() < 2.7);
            Assert.Equal(170, squares.Last());
        }
    }

    class ShapeContainer
    {
        public string ContainerName { get; set; }

        public List<IShape> Shapes { get; set; }
    }
}
