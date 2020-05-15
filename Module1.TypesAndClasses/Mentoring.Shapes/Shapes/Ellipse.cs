using Mentoring.Shapes.Interfaces;
using System;

namespace Mentoring.Shapes.Shapes
{
    public class Ellipse : BaseShape
    {
        private readonly int _radius1;
        private readonly int _radius2;
         
        public Ellipse(int radius1, int radius2, Units unit = Units.Meter) : base(unit)
        {
            _radius1 = radius1;
            _radius2 = radius2;
        }

        public override ShapeTypes shapeType => ShapeTypes.Ellipse;

        #region public methods

        public override double Perimeter()
        {
            return 2 * Math.PI * Math.Sqrt((Math.Pow(_radius1, 2) + Math.Pow(_radius2, 2)) / 8);
        }

        public override double Square()
        {
            return Math.Round(_radius1 * _radius2 * Math.PI);
        }

        public override string ToString() => $"Shape: '{GetType().Name}'. Square = {Square()}, perimeter = {Perimeter()}";
        
        public void Print()
        {
            Console.WriteLine($"Ellipse. Square: {Square()}, perimeter:{Perimeter()}. Radius 1: {_radius1}, Radius 2 : {_radius2}");
        }

        #endregion
    }
}