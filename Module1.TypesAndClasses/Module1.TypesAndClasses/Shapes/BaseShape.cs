using Module1.TypesAndClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Shapes
{
   public abstract class BaseShape: IShape
    {
        public enum MetricName : byte  {sm=2, mm=3, m=1}

        #region Public Methods
        public virtual long Square()
        {
            throw new NotImplementedException();
        }
        public virtual string Metric()
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
            Console.WriteLine(m.Metric() + " " + this.Metric()+ m.Perimeter() + this.Perimeter());
            if (m.Metric() == this.Metric())
            {
                return m.Perimeter() == this.Perimeter();
            }
            else
                switch (m.Metric()+" "+ this.Metric())
                {
                    case "m sm":
                        {
                            return m.Perimeter() * 100 == this.Perimeter() ;
                        }
                   case "m mm":
                        {
                            return m.Perimeter() * 1000 == this.Perimeter() ;
                        }
                    case "sm m":
                        {
                            return m.Perimeter() == this.Perimeter() * 100;
                        }
                    case "sm mm":
                        {
                            return m.Perimeter() * 10 == this.Perimeter() ;
                        }
                    case "mm sm":
                        {
                            return m.Perimeter()  == this.Perimeter()*10 ;
                        }
                    case "mm m":
                        {
                            return m.Perimeter()== this.Perimeter() * 1000;
                        }
                    default:
                        { throw new Exception("Not valid Metric Name"); }
                }

        }

        public static bool operator ==(BaseShape obj1, BaseShape obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                throw new ArgumentNullException(" One of objects is null");
            }
            else
            {
                long Square1 = obj1.Square();
                switch (obj1.Metric().ToString())
                {
                    case "m":
                        {
                            Square1 *= 10000;
                            break;
                        }
                    case "sm":
                        {
                            Square1 *= 100;
                            break;
                        }
                                                            }
                long Square2 = obj2.Square();
                switch (obj2.Metric().ToString())
                {
                    case "m":
                        {
                            Square2 *= 10000;
                            break;
                        }
                    case "sm":
                        {
                            Square2 *= 100;
                            break;
                        }
                }

                return Square1 == Square2;
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
                long Square1 = obj1.Square();
                switch (obj1.Metric().ToString())
                {
                    case "m":
                        {
                            Square1 *= 10000;
                            break;
                        }
                    case "sm":
                        {
                            Square1 *= 100;
                            break;
                        }
                }
                long Square2 = obj2.Square();
                switch (obj2.Metric().ToString())
                {
                    case "m":
                        {
                            Square2 *= 10000;
                            break;
                        }
                    case "sm":
                        {
                            Square2 *= 100;
                            break;
                        }
                }

                return Square1 != Square2;
            }
        }
               #endregion
    }
}
