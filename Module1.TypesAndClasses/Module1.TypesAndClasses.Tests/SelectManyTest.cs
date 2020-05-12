using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Module1.TypesAndClasses.Tests
{
    class ShapeContainer
    {
        public string ContainerName { get; set; }
        
        public List<IShape> Shapes { get; set; }
    }

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
                        new EquilateralTriangle(3, Units.centimeters),
                        new EquilateralTriangle(7.8, Units.millimeters),
                        new EquilateralTriangle(5, Units.meters)
                    }
                },
                new ShapeContainer
                {
                    ContainerName = "Circles",
                    Shapes = new List<IShape> {
                        new Circle(5, Units.meters),
                        new Circle(8, Units.millimeters),
                        new Circle(2.6, Units.centimeters)
                    }
                },
                new ShapeContainer
                {
                    ContainerName = "Ellipses",
                    Shapes = new List<IShape> {
                        new Ellipse(4, 6, Units.millimeters),
                        new Ellipse(6, 9, Units.centimeters),
                        new Ellipse(1, 2, Units.meters)
                    }
                },
                new ShapeContainer
                {
                    ContainerName = "Rectangles",
                    Shapes = new List<IShape> {
                        new Rectangle(5, 8, Units.centimeters),
                        new Rectangle(10, 24, Units.millimeters),
                        new Rectangle(1, 2, Units.meters)
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
}
