using Module1.TypesAndClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Shapes
{
    

    public abstract class BaseShape : IShape
    {
        #region IShape methods

        public abstract double Perimeter();

        public abstract double Square();

        #endregion

        public Metric Metric { get; }

        protected BaseShape(Metric metric)
        {
            this.Metric = metric;
        }

        protected static double ToMeters(Metric valueMetric, double val)
        {
            switch (valueMetric)
            {
                case Metric.Metr:
                    return val;
                case Metric.Milimetr:
                    return val / 1000;
                case Metric.Kilometr:
                    return val * 1000;
                case Metric.Santimetr:
                    return val / 100;
                default:
                    throw new NotSupportedException($"The metric {valueMetric} is not supported.");
            }
        }
    }
}
