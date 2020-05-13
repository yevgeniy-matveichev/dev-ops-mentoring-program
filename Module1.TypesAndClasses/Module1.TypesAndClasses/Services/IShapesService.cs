using System;
using System.Collections.Generic;
using System.Text;
using Mentoring.Shapes.Interfaces;

namespace Module1.TypesAndClasses.Services
{
   public interface IShapesService
    {
        string ReadSHape(ShapeType shapetype);
        string IShape();
    }
}
