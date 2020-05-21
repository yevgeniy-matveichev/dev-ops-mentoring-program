using Mentoring.Shapes.Interfaces;
using System;
using Mentoring.DataAccess.Interfaces;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Shapes;
using Newtonsoft.Json;


namespace Module1.TypesAndClasses.Services
{
    public class ShapesService : IShapesService
    {
        #region  private fields

        private readonly IShapeRepository _shapeRepository; 

        #endregion

        #region constructor
        
        public ShapesService(IShapeRepository shapeRepository)
        {
            _shapeRepository = shapeRepository ?? throw new ArgumentNullException(nameof(shapeRepository));
        } 

        #endregion

        public IShape ReadShape(ShapeTypes shapeType)
        {
            string shapeName = $"{shapeType}.json";
            string shape = _shapeRepository.ReadShape(shapeName)
            ??  @"{"
                    + "\"Unit\": \"Centimeter\","
                    + "\"Radius\": 10"
                    + "}";
          
            switch (shapeType)
            {
                case ShapeTypes.EquilateralTriangle:
                    {
                        EquilateralTriangleModel triangleModel = JsonConvert.DeserializeObject<EquilateralTriangleModel>(shape);
                        IShape Model = new EquilateralTriangle(triangleModel.Side, triangleModel.Unit);
                        return Model;
                        // cr: please use lowerCamelCase for local variables
                        // cr: this would be better to do in 1 line: new EquilateralTriangle(triangleModel.SideInMeters, triangleModel.Unit);
                    }
                case ShapeTypes.Circle: 
                    {
                        CircleModel circleModel = JsonConvert.DeserializeObject<CircleModel>(shape);
                        IShape Model = new Circle(circleModel.Radius, circleModel.Unit);
                        return Model;
                    }
                case ShapeTypes.Rectangle:
                    {
                        RectangleModel rectangleModel = JsonConvert.DeserializeObject<RectangleModel>(shape);
                        IShape Model = new Rectangle(rectangleModel.SideA, rectangleModel.SideB, rectangleModel.Unit);
                        return Model;
                    }
                case ShapeTypes.Ellipse:
                    {
                        EllipseModel ellipseModel = JsonConvert.DeserializeObject<EllipseModel>(shape);
                        IShape Model = new Ellipse(ellipseModel.Radius1, ellipseModel.Radius2, ellipseModel.Unit);
                        return Model;
                    }
                default:
                    {
                        throw new ArgumentException($"This method {shapeType} is invalid or not implemented yet"); ;
                    }
            }
        }
    }
}
