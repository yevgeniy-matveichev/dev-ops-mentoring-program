using Mentoring.DataAccess.ShapesRepository;
using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Factories;
using Module1.TypesAndClasses.Services;
using System;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Repository
{

    /// <summary>
    /// private mthd
    /// </summary>
    public class ShapesRepository
    {
        [Theory]
        [InlineData(ShapeTypes.Circle, typeof(CircleService))]
        [InlineData(ShapeTypes.Ellipse, typeof(EllipseService))]
        [InlineData(ShapeTypes.EquilateralTriangle, typeof(TriangleService))]
        [InlineData(ShapeTypes.Rectangle, typeof(RectangleService))]
        public void ShapesRepository_WriteShape(ShapeTypes type, Type t)
        { 
            switch (type)
            {
                case ShapeTypes.EquilateralTriangle:
                    {
                        var shape = new TriangleService();
                        //shapesRepository.ShapesRepository_WriteShape
                        //ShapesRepository<t> shapesRepository =
                        break;
                    }
                case ShapeTypes.Circle:
                    {
                        var shape = new CircleService();

                        break;
                    }
                case ShapeTypes.Rectangle:
                    {
                        var shape = new RectangleService();

                        break;
                    }
                case ShapeTypes.Ellipse:
                    {
                        var shape = new EllipseService();

                        break;
                    }
                default:
                    {
                        throw new ArgumentException($"This method {type} is invalid or not implemented yet"); ;
                    }
            }
        }

       // private ShapesRepository<EllipseModel> _repository  = new ShapesRepository<EllipseModel>();

        //[Fact]
        //public void ShapeServiceFactory_Throws()
        //{
        //    Assert.Throws<ArgumentException>(() => _shapeServiceFactory.Create(ShapeTypes.None));
        //}
    }
}