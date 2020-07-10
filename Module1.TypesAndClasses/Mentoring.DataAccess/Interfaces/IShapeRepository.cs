using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.DataAccess.Interfaces
{
    public interface IShapeRepository<T> where T: class
    {
        T ReadShapeExample(string shapeName);

        T ReadShape(string shapeFilePath);

        void WriteShape(string filePath, T modelType);
    }
}
