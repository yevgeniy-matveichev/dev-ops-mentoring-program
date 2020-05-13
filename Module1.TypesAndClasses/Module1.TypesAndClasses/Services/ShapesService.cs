using Mentoring.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Mentoring.Shapes;
using MentoringDataAccess.Interfaces;
using MentoringDataAccess.ShapesRepository;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Shapes;

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
            if (shapeRepository != null) 
            { 
                IShapeRepository _shapeRepository = shapeRepository; 
            }
            else 
            { 
                throw new ArgumentException("shapeRepository parameter is invalid or null"); 
            }
           
        }
        #endregion

        public IShape ReadShape(ShapeType shapeType)
        {
            string shapeName = $"{shapeType}.json";
            // todo: call repository
            //private string _shapeRepository = ReadShape(shapeType);
            string shape = _shapeRepository.ReadShape(shapeName);
            // todo: parse the string from JSON
            if (shape == null)
            {
                shape = @"{"
                    + "\"Unit\": \"Centimeters\","
                    + "\"Radius\": 10"
                    + "}";
            }
            //  CircleModel circleModel = JsonSerializer.Deserialize<CircleModel>(shape);
            switch (shapeType)
            {
                //if (shapeType == ShapeType.Circle)
                case ShapeType.Circle:
                    {
                        CircleModel empObj = JsonConvert.DeserializeObject<CircleModel>(shape);

                        if (Enum.IsDefined(typeof(Units), empObj.Unit))
                        {
                            Units metricName = (Units)Enum.Parse(typeof(Units), empObj.Unit);
                            IShape circleModel = new Circle(empObj.Radius, metricName);
                            return circleModel;
                        }
                        else
                        {
                            throw new Exception("not valid Unit in json file");
                        }
                    }
                default: return null;
                 
            }
        }
    }
}
