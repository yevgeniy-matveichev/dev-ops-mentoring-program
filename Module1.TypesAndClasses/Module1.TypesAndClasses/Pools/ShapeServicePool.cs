using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module1.TypesAndClasses.Factories
{
    public class ShapeServicePool
    {
        private readonly IEnumerable<IShapesService> _shapesServices;

        public ShapeServicePool(IEnumerable<IShapesService> shapesServices)
        {
            _shapesServices = shapesServices ?? throw new ArgumentNullException(nameof(shapesServices));
        }

        public IShapesService Create(ShapeTypes shapeType)
        {
            switch (shapeType)
            {
                case ShapeTypes.EquilateralTriangle:
                    {
                        //return new TriangleService();
                        return _shapesServices.Single(c => c.Name == nameof(TriangleService));
                    }
                case ShapeTypes.Circle:
                    {
                        //return new CircleService();
                        return _shapesServices.Single(c => c.Name == nameof(CircleService));
                    }
                case ShapeTypes.Rectangle:
                    {
                        //return new RectangleService();
                        return _shapesServices.Single(c => c.Name == nameof(RectangleService));
                    }
                case ShapeTypes.Ellipse:
                    {
                        //return new EllipseService();
                        return _shapesServices.Single(c => c.Name == nameof(EllipseService));
                    }
                default:
                    {
                        throw new ArgumentException($"This method {shapeType} is invalid or not implemented yet"); ;
                    }
            }
        }
    }
}