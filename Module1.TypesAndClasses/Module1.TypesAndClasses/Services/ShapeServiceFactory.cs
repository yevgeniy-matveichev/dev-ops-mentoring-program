using Mentoring.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Services
{
    class ShapeServiceFactory
    {
        public IShapesService Create(ShapeTypes shapeType)
        {
            switch (shapeType)
            {
                case ShapeTypes.EquilateralTriangle:
                    {
                        return new TriangleService();
                    }
                case ShapeTypes.Circle:
                    {
                        return null;
                        //return new CircleService();
                    }
                case ShapeTypes.Rectangle:
                    {
                        return new RectangleService();
                    }
                case ShapeTypes.Ellipse:
                    {
                        return null;
                    }
                default:
                    {
                        throw new ArgumentException($"This method {shapeType} is invalid or not implemented yet");
                    }
            }
        }
    }
}
