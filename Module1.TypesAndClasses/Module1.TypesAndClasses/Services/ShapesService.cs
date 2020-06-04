using Mentoring.Shapes.Interfaces;
using System;
using Mentoring.DataAccess.Interfaces;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Shapes;
using Newtonsoft.Json;
using Mentoring.DataAccess.ShapesRepository;

namespace Module1.TypesAndClasses.Services
{
    public class ShapesService : IShapesService
    {
        #region  private fields

        #endregion

        #region constructor
        
        public ShapesService()
        {
           // _shapeRepository = shapeRepository ?? throw new ArgumentNullException(nameof(shapeRepository));
        } 

        #endregion

        public IShape ReadShape(ShapeTypes shapeType)
        {
            string shapeName = $"{shapeType}.json";
                      
            switch (shapeType)
            {
                case ShapeTypes.EquilateralTriangle:
                    {
                        EquilateralTriangleModel triangleModel = new ShapesRepository<EquilateralTriangleModel>().ReadShape(shapeName);
                        return new EquilateralTriangle(triangleModel.Side, triangleModel.Unit);
                    }
                case ShapeTypes.Circle: 
                    {
                        CircleModel circleModel = new ShapesRepository<CircleModel>().ReadShape(shapeName);
                        return new Circle(circleModel.Radius, circleModel.Unit);
                    }
                case ShapeTypes.Rectangle:
                    {
                        RectangleModel rectangleModel = new ShapesRepository<RectangleModel>().ReadShape(shapeName);
                        return new Rectangle(rectangleModel.SideA, rectangleModel.SideB, rectangleModel.Unit);
                    }
                case ShapeTypes.Ellipse:
                    {
                        EllipseModel ellipseModel = new ShapesRepository<EllipseModel>().ReadShape(shapeName);
                        return new Ellipse(ellipseModel.Radius1, ellipseModel.Radius2, ellipseModel.Unit);
                    }
                default:
                    {
                        throw new ArgumentException($"This method {shapeType} is invalid or not implemented yet"); ;
                    }
            }
        }
    }
}
