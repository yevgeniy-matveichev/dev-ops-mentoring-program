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
                        ShapesRepository<EquilateralTriangleModel> reader = new ShapesRepository<EquilateralTriangleModel>();
                        EquilateralTriangleModel triangleModel = reader.ReadShape(shapeName);
                        return new EquilateralTriangle(triangleModel.Side, triangleModel.Unit);
                    }
                case ShapeTypes.Circle: 
                    {
                        ShapesRepository<CircleModel> reader = new ShapesRepository<CircleModel>();
                        CircleModel circleModel = reader.ReadShape(shapeName);
                        return new Circle(circleModel.Radius, circleModel.Unit);
                    }
                case ShapeTypes.Rectangle:
                    {
                        ShapesRepository<RectangleModel> reader = new ShapesRepository<RectangleModel>();
                        RectangleModel rectangleModel = reader.ReadShape(shapeName);
                        return new Rectangle(rectangleModel.SideA, rectangleModel.SideB, rectangleModel.Unit);
                    }
                case ShapeTypes.Ellipse:
                    {
                        ShapesRepository<EllipseModel> reader = new ShapesRepository<EllipseModel>();
                        EllipseModel ellipseModel = reader.ReadShape(shapeName);
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
