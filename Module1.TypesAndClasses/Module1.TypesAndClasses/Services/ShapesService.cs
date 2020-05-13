using Mentoring.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Mentoring.Shapes;
using MentoringDataAccess.Interfaces;

namespace Module1.TypesAndClasses.Services
{
    class ShapesService : IShapesService
    {
        #region  private fields

        // private readonly IShapeRepository _sha..
        #endregion

        ShapesService(IShapeRepository shapeRepository)
        {
            // argumentnull exception
        }

        public IShape ReadShape(ShapeType shapeType)
        {
            string shapeName = $"{shapeType}.json";
            // todo: call repository
            // todo: string shape = _shapeRepository.Read(shapeName);
            // todo: parse the string from JSON
            
            return null;
        }
    }
}
