using System;
using System.Collections.Generic;
using System.Text;
using Mentoring.Shapes.Interfaces;


namespace Mentoring.DataModel.Shapes
{
    public class RectangleModel
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public Units Unit { get; set; }
    }
}
