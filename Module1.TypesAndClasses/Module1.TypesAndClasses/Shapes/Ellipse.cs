using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public class Ellipse :  AbstractShape, IShape
    {
        private int radius1;
        private int radius2;

        public Units unit { get; }

     
        public Units Units => throw new NotImplementedException();

        public Ellipse(int radius1, int radius2, Units units = Units.meter)
        {
            this.radius1 = radius1;
            this.radius2 = radius2;
            this.unit = units;
        }




        public double Perimeter()
        {
            return 2 * Math.PI * Math.Sqrt((Math.Pow(radius1, 2) + Math.Pow(radius2, 2)) / 8);
        }

        public double Square()
        {
            return Math.Round(radius1 * radius2 * Math.PI);
        }
        public override string ToString() => $"Shape: '{GetType().Name}'. Square = {Square()}, perimeter = {Perimeter()}";
        public override bool Equals(object obj)
        {
            var shape = obj as IShape;

            if (shape != null)
            {
                return Convert(unit, this.Perimeter()) == Convert(shape.Units, shape.Perimeter());
            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public void Print()
        {
            Console.WriteLine($"Ellipse. Square: {Square()}, perimeter:{Perimeter()}. Radius 1: {radius1}, Radius 2 : {radius2}" );
        }
    }
}