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
        
        private string _shapeFilePath;

        #endregion

        #region constructor

        public ShapesService()
        {
           // _shapeRepository = shapeRepository ?? throw new ArgumentNullException(nameof(shapeRepository));
        }

        #endregion

        public IShape WriteShape(string shapeFilePath, IShape shape)
        {
            switch (shape.shapeType)
            {
                default:
                    {
                        throw new ArgumentException($"This method {shape.shapeType} is invalid or not implemented yet"); ;
                    }
            }
        }        

        public IShape ReadShape(string shapeFilePath, ShapeTypes shapeType)
        {
            switch (shapeType)
                {
                    case ShapeTypes.EquilateralTriangle:
                        {
                            EquilateralTriangleModel triangleModel = new ShapesRepository<EquilateralTriangleModel>().ReadShape(shapeFilePath);
                            return new EquilateralTriangle(triangleModel.Side, triangleModel.Unit);
                        }
                    case ShapeTypes.Circle:
                        {
                            CircleModel circleModel = new ShapesRepository<CircleModel>().ReadShape(shapeFilePath);
                            return new Circle(circleModel.Radius, circleModel.Unit);
                        }
                    case ShapeTypes.Ellipse:
                        {
                            EllipseModel ellipseModel = new ShapesRepository<EllipseModel>().ReadShape(shapeFilePath);
                            return new Ellipse(ellipseModel.Radius1, ellipseModel.Radius2, ellipseModel.Unit);
                        }
                    default:
                        {
                            throw new ArgumentException($"This method {shapeType} is invalid or not implemented yet"); ;
                        }
            }
        }

        #region ExampleMethod
        public IShape ReadShapeExample(ShapeTypes shapeType)
        {
            string shapeName = $"{shapeType}.json";
                      
            switch (shapeType)
            {
                case ShapeTypes.EquilateralTriangle:
                    {
                        EquilateralTriangleModel triangleModel = new ShapesRepository<EquilateralTriangleModel>().ReadShapeExample(shapeName);
                        return new EquilateralTriangle(triangleModel.Side, triangleModel.Unit);
                    }
                case ShapeTypes.Circle: 
                    {
                        CircleModel circleModel = new ShapesRepository<CircleModel>().ReadShapeExample(shapeName);
                        return new Circle(circleModel.Radius, circleModel.Unit);
                    }
                case ShapeTypes.Ellipse:
                    {
                        EllipseModel ellipseModel = new ShapesRepository<EllipseModel>().ReadShapeExample(shapeName);
                        return new Ellipse(ellipseModel.Radius1, ellipseModel.Radius2, ellipseModel.Unit);
                    }
                default:
                    {
                        throw new ArgumentException($"This method {shapeType} is invalid or not implemented yet"); ;
                    }
            }
        }
#endregion
    }
}
