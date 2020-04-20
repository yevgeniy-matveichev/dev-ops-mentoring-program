using Module1.TypesAndClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Shapes
{
   public abstract class BaseShape: IShape
    {
        public enum MetricName: byte
        { 
          sm,
          mm,
          m
        }
        #region Public Methods
        public virtual long Square()
        {
            throw new NotImplementedException();
        }
        public virtual string metricName()
        {
            throw new NotImplementedException();
        }
        public virtual int Perimeter()
        {
            throw new NotImplementedException();
        }
        public virtual string ShapeName()
        { 
            throw new NotImplementedException();
        }
        #endregion

        #region Public Overrided Methods
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            BaseShape m = obj as BaseShape;
            if (m.MetricName != this.MetricName) { }
            return m.Perimeter() == this.Perimeter();
        }

        public static bool operator ==(BaseShape obj1, BaseShape obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                throw new ArgumentNullException(" One of objects is null");
            }
            else
            {
                obj1 = new Rectangle(1, 1, MetricName.sm);
                return obj1.Square() == obj2.Square();
            }
        }

        public static bool operator !=(BaseShape obj1, BaseShape obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                throw new ArgumentNullException(" One of objects is null");
            }
            else
            {
                return obj1.Square() != obj2.Square();
            }
        }
        #endregion
    }
}
