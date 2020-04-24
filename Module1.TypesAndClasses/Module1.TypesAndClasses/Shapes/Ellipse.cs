using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public class Ellipse : BaseShape
    {
        private double radius1;
        private double radius2;

        public Ellipse(double radius1, double radius2): base(Metric.Metr)
        {
            this.radius1 = radius1;
            this.radius2 = radius2;
        }

        public override double Perimeter()
        {
            return Convert.ToInt32(2 * Math.PI * Math.Sqrt((Math.Pow(radius1, 2) + Math.Pow(radius2, 2)) / 8));
        }

        public override double Square()
        {
            return radius1 * radius2 * Math.PI;
        }

        public override string ToString()
        {
            return $"Shape: '{GetType().Name}'. Square = {Square()}, perimeter = {Perimeter()}";
        }

        public override bool Equals(object obj)
        {
            var shape = obj as IShape;

            if (shape != null)
            {
                return this.Perimeter() == shape.Perimeter();
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Ellipse ishape1, IShape ishape2)
        {
            return ishape1.Square() == ishape2.Square();
        }

        public static bool operator !=(Ellipse shape1, IShape ishape2)
        {
            return ishape2.Square() != ishape2.Square();
        }
    }
}
