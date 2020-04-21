using Module1.TypesAndClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Shapes
{
    public class BaseShape : IShape
    {
        public enum units
        {
            mm = 1,
            dm = 10,
            cm = 100,
            m = 1000,
            km = 1000000
        }

        public readonly units _unit;

        protected BaseShape(units u)
        {
            _unit = u;
        }

        virtual public int Perimeter()
        {
            return 0;
        }

        virtual public long Square()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"Shape: '{GetType().Name}'. Square = {Square()}, perimeter = {Perimeter()}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            BaseShape circle = (BaseShape)obj;
            return this.Perimeter() * Convert.ToInt32(this._unit) == circle.Perimeter() * Convert.ToInt32(circle._unit);
        }

        public static bool operator ==(BaseShape obj1, BaseShape obj2)
        {
            return obj1.Square() * Convert.ToInt64(obj1._unit) * Convert.ToInt64(obj1._unit) == obj2.Square() * Convert.ToInt64(obj1._unit) * Convert.ToInt64(obj1._unit);
        }

        public static bool operator !=(BaseShape obj1, BaseShape obj2)
        {
            return !(obj1.Square() * Convert.ToInt64(obj1._unit) * Convert.ToInt64(obj1._unit) == obj2.Square() * Convert.ToInt64(obj1._unit) * Convert.ToInt64(obj1._unit));
        }
    }
}
