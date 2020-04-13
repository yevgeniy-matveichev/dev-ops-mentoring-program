using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public class Ellipse : IShape
    {
        private int radius1;
        private int radius2;

        public Ellipse(int radius1, int radius2)
        {
            this.radius1 = radius1;
            this.radius2 = radius2;
        }




        public int Perimeter()
        {
            return Convert.ToInt32(2 * Math.PI * Math.Sqrt((Math.Pow(radius1, 2) + Math.Pow(radius2, 2)) / 8));
        }

        public long Square()
        {
            return Convert.ToInt64(Math.Round(radius1 * radius2 * Math.PI));
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
