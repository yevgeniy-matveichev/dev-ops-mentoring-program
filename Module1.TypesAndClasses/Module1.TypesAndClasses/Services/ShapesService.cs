using Mentoring.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Mentoring.Shapes;

namespace Module1.TypesAndClasses.Services
{
    class ShapesService : IShapesService
    {
        #region  private fields

        private ShapeType _shapeType;
        
        #endregion

        public string IShape()
        {
            throw new NotImplementedException();
        }

        public string ReadSHape(ShapeType shapetype)
        {
            _shapeType = shapetype;
            return $"{_shapeType}.json";
        }
    }
}
