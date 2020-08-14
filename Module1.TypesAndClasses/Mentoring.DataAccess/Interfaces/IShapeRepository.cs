using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.DataAccess.Interfaces
{
    public interface IShapeRepository<T> where T: class
    {
        T ReadShapeExample(string shapeName);

        Task<T> ReadShapeExampleAsync(string shapeName);

        T ReadShape(string shapeFilePath);

        Task<T> ReadShapeAsync(string shapeFilePath);

        void WriteShape(string filePath, T modelType);
    }
}
