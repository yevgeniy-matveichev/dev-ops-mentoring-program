using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.DataModel.Shapes
{
    public class EllipseModel
    {
        public double Radius1 { get; set; } //SM: not double because of types in th Shape Ellipse Class
        public double Radius2 { get; set; }
        public string Unit { get; set; }
    }
}
