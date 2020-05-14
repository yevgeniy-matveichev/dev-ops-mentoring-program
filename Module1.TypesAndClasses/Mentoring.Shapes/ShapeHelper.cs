using System;
using System.Collections.Generic;
using System.Text;
using Mentoring.Shapes.Interfaces;

namespace Mentoring.Shapes
{
    static class ShapeHelper
    {
        public static double ToMeters(Units unit, double value)
        {
            switch (unit)
            {
                case Units.Meters:
                    return value;
                case Units.Centimeters:
                    return value / 100;
                case Units.Millimeters:
                    return value / 1000;
                default:
                    throw new NotSupportedException($"The unit of measurement {unit} is not supported.");
            }
        }
    }
}
