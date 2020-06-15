using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Factories

{
    public class ShapeServiceFactory
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
                        return new CircleService();
                    }
                case ShapeTypes.Rectangle:
                    {
                        return new RectangleService();
                    }
                case ShapeTypes.Ellipse:
                    {
                        return new EllipseService();
                    }
                default:
                    {
                        throw new ArgumentException($"This method {shapeType} is invalid or not implemented yet"); ;
                    }
            }
        }
    }
}



