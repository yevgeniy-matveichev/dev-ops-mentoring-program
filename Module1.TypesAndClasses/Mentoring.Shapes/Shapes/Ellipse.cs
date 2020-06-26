using Mentoring.DataAccess;
using Mentoring.Shapes.Interfaces;
using System;

namespace Mentoring.Shapes.Shapes
{
    public class Ellipse : BaseShape
    {
        private readonly double _radius1;
        private readonly double _radius2;
        public readonly Units _unit;

        public Ellipse(double radius1, double radius2, Units unit) : base(unit)
        {
            _radius1 = ShapeHelper.ToMeters(unit, radius1);
            _radius2 = ShapeHelper.ToMeters(unit, radius2);
            _unit = unit;
        }

        public override ShapeTypes shapeType => ShapeTypes.Ellipse;

        #region public methods

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Math.Sqrt((Math.Pow(_radius1, 2) + Math.Pow(_radius2, 2)) / 8);
        }

        public override double GetSquare()
        {
            return Math.Round(_radius1 * _radius2 * Math.PI);
        }

        public override string ToString() => $"Shape: '{GetType().Name}'. Square = {GetSquare()}, perimeter = {GetPerimeter()}";
        
        public void Print()
        {
            Console.WriteLine($"Ellipse. Square: {GetSquare()}, perimeter:{GetPerimeter()}. Radius 1: {_radius1}, Radius 2 : {_radius2}");
        }

        #endregion
    }
}