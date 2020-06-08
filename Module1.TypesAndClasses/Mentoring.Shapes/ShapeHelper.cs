using Mentoring.DataAccess;
using System;

namespace Mentoring.Shapes
{
    static class ShapeHelper
    {
        public static double ToMeters(Units unit, double value)
        {
            switch (unit)
            {
                case Units.Meter:
                    return value;
                case Units.Centimeter:
                    return value / 100;
                case Units.Millimeter:
                    return value / 1000;
                default:
                    throw new NotSupportedException($"The unit of measurement {unit} is not supported.");
            }
        }
    }
}
