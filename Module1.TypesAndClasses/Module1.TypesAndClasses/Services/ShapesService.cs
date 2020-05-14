using Mentoring.Shapes.Interfaces;
using System;
using MentoringDataAccess.Interfaces;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Shapes;
using Newtonsoft.Json;

namespace Module1.TypesAndClasses.Services
{
    class ShapesService : IShapesService
    {
        #region  private fields

        private readonly IShapeRepository _shapeRepository; 

        #endregion

        #region constructor
        
        ShapesService(IShapeRepository shapeRepository)
        {
            
              _shapeRepository = shapeRepository ?? throw new ArgumentException("shapeRepository parameter is invalid or null");
        } 

        #endregion

        public IShape ReadShape(ShapeType shapeType)
        {
            string shapeName = $"{shapeType}.json";
            string shape = _shapeRepository.ReadShape(shapeName)
            ??  @"{"
                    + "\"Unit\": \"Centimeters\","
                    + "\"Radius\": 10"
                    + "}";

            // cr: good, nice to have this knowledge
            // cr: for automatic serialization with Newtonsoft, please see this article:
            // cr: https://bytefish.de/blog/enums_json_net/          
            
            switch (shapeType)
            {
                 case ShapeType.Circle: // cr: good. please implement for other figures as well (generic method can help)
                    {
                        CircleModel circleModel = JsonConvert.DeserializeObject<CircleModel>(shape);
                        
                        if (Enum.IsDefined(typeof(Units), circleModel.Unit))
                        {
                            Units metricName = (Units)Enum.Parse(typeof(Units), circleModel.Unit);
                            IShape Model = new Circle(circleModel.Radius, metricName);
                            return Model;
                        }
                        else
                        {
                            throw new Exception("Not valid Unit in json file");
                        }
                    }
                case ShapeType.Rectangle:
                    {
                        RectangleModel rectangleModel = JsonConvert.DeserializeObject<RectangleModel>(shape);

                        if (Enum.IsDefined(typeof(Units), rectangleModel.Unit))
                        {
                            Units metricName = (Units)Enum.Parse(typeof(Units), rectangleModel.Unit); 
                            IShape Model = new Rectangle(rectangleModel.SideA, rectangleModel.SideB, metricName);
                            return Model;
                        }
                        else
                        {
                            throw new Exception("Not valid Unit in json file");
                        }
                    }
                case ShapeType.Ellipse:
                    {
                        EllipseModel ellipseModel = JsonConvert.DeserializeObject<EllipseModel>(shape);

                        if (Enum.IsDefined(typeof(Units), ellipseModel.Unit))
                        {
                            Units metricName = (Units)Enum.Parse(typeof(Units), ellipseModel.Unit);
                            IShape Model = new Ellipse(ellipseModel.Radius1, ellipseModel.Radius2, metricName);
                            return Model;
                        }
                        else
                        {
                            throw new Exception("Not valid Unit in json file");
                        }
                    }
                default:
                    {
                        throw new Exception($"This method {shapeType} is invalid or not implemented yet"); ;
                    }
                 
            }
        }
    }
}
