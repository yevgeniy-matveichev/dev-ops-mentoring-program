using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Module1.TypesAndClasses.Tests
{
    public class KatsiarynaTests
    {
        List<IShape> shapes = new List<IShape> {
                new EquilateralTriangle(3, Units.centimeters),
                new EquilateralTriangle(7.8, Units.millimeters),
                new EquilateralTriangle(5, Units.meters),
                new Circle(5, Units.meters),
                new Circle(8, Units.millimeters),
                new Circle(2.6, Units.centimeters),
                new Ellipse(4, 6, Units.millimeters),
                new Ellipse(6, 9, Units.centimeters),
                new Ellipse(1, 2, Units.meters),
                new Rectangle(5, 8, Units.centimeters),
                new Rectangle(10, 24, Units.millimeters),
                new Rectangle(1, 2, Units.meters)
            };

        [Fact]
        public void Test_SinglePerimeter()
        {
            /* a. Выбрать единственный элемент с заданным периметром (Exception, если не существует) */

            IShape shape = shapes.Single(s => s.Perimeter() == 0.09);
            Assert.Equal(shapes[0], shape);
        } 

        [Fact]
        public void Test_Circle_LargestSquare()
        {
            /* b. Выбрать Circle с наибольшей площадью, при этом площадь должна быть не менее 1 квадратного метра 
                 (Exception, если такой Circle в списке отсутствует) */

            // здесь все работает ок, только нужно учесть единицы измерения, а лучше, если ребята все таки воспользуются методом ToMeters() :)
            double circle = shapes.OfType<Circle>().Where(s => s.Square() >= 1).Max(s => s.Square());
            Assert.Equal(shapes[3].Square(), circle);
        }

        [Fact]
        public void Test_Rectangle_SmallestPerimeter()
        {
            /* c. Выбрать Rectangle с наименьшим периметром (no exceptions) */

            double rectangle = shapes.OfType<Rectangle>().Min(s => s.Perimeter());
            Assert.Equal(shapes[10].Perimeter(), rectangle);
        }

        [Fact]
        public void Test_RectangleCircle_Filtered()
        {
            /* d. Отфильтровать список  по типу: выбрать только фигуры типа Rectangle и Circle (оба типа в одном) */

            List<IShape> rc = shapes.Where(s => s.GetType().Name == "Rectangle" || s.GetType().Name == "Circle").ToList();
            Assert.Contains(shapes[3], rc);
            Assert.Contains(shapes[4], rc);
            Assert.Contains(shapes[5], rc);
            Assert.Contains(shapes[9], rc);
            Assert.Contains(shapes[10], rc);
            Assert.Contains(shapes[11], rc);
            Assert.DoesNotContain(shapes[6], rc);
            Assert.DoesNotContain(shapes[1], rc);
        }

        [Fact]
        public void Test_5() 
        {
            /* e. Выбрать числовые значения всех пощадей, отфильтрованных по возрастанию, с учетом единиц измерения
                   i. При помощи Select 
                   ii. При помощи SelectMany */
        }
    }
}
