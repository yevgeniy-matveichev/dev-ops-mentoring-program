using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
<<<<<<< HEAD
=======

>>>>>>> feature/task3
    public class Circle : BaseShape
    {
        public readonly double _radius;
        public readonly Units _unit;
<<<<<<< HEAD

        #region constructor
        public Circle(double radius, Units u) : base(u)
=======
        public override ShapeType ShapeName => ShapeType.Circle;

        #region constructor
        public Circle(double radius, Units u) : base(u)
>>>>>>> feature/task3
        {
            if (radius < 0)
            {
                throw new ArgumentException($"Radius cannot be less than 0! Actual value was '{radius}'");
            }

            _radius = radius;
            _unit = u;
        }
<<<<<<< HEAD

        #endregion

        override public double Perimeter()
        {
=======

        #endregion

        override public double Perimeter()
        {
>>>>>>> feature/task3
            var result = checked(2 * Math.PI * _radius);
            return result;
        }

        override public double Square()
        {
            double result = checked(Math.PI * Math.Pow(_radius, 2));
            return result;
        }

        public override string ToString()
        {
            return $"Shape: '{GetType().Name}'. Square = {Square()}, perimeter = {Perimeter()}, radius = {this._radius}";
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> feature/task3
