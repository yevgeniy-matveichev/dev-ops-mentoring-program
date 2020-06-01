using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.DataAccess.Interfaces
{
 /*   public interface IShapeRepository
    {
        public string ReadShape(string shapeName);

        public void WriteShape(string filePath);
    }
    */
    public interface IShapeRepository<T> where T:class
    {
        public T ReadShape(string shapeName);

        public void WriteShape(string filePath);
    }
}

