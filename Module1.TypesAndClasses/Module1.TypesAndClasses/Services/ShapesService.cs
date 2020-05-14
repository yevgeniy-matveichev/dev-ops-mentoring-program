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

      private readonly IShapeRepository _shapeRepository; // cr: tabulation

        #endregion

        #region constructor // cr: please add an empty line after
        ShapesService(IShapeRepository shapeRepository)
        {
            // cr: can be implemented in 1 line: _shapeRepository = shapeRepository ?? throw new ArgumentException...; 
            if (shapeRepository != null) 
            {
              _shapeRepository = shapeRepository; 
            }
            else 
            { 
                throw new ArgumentException("shapeRepository parameter is invalid or null"); 
            }
            // cr: extra line here is not needed
        } // cr: add an empty line please
        #endregion

        public IShape ReadShape(ShapeType shapeType)
        {
            string shapeName = $"{shapeType}.json";
            // todo: call repository
            //private string _shapeRepository = ReadShape(shapeType);
            string shape = _shapeRepository.ReadShape(shapeName)
            ??  @"{"
                    + "\"Unit\": \"Centimeters\","
                    + "\"Radius\": 10"
                    + "}";
            
           
            switch (shapeType)
            {
                //if (shapeType == ShapeType.Circle) // cr: please remove it
                case ShapeType.Circle: // cr: good. please implement for other figures as well (generic method can help)
                    {
                        // cr: good, nice to have this knowledge
                        // cr: for automatic serialization with Newtonsoft, please see this article:
                        // cr: https://bytefish.de/blog/enums_json_net/

                        CircleModel circleModel = JsonConvert.DeserializeObject<CircleModel>(shape);
                        //  CircleModel circleModel = JsonSerializer.Deserialize<CircleModel>(shape); // Like in the task
                        Console.WriteLine(circleModel.ToString());
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
                default: return null; // cr: please add curly brackets, each on a separate line
                 // cr: extra line
            }
        }
    }
}
