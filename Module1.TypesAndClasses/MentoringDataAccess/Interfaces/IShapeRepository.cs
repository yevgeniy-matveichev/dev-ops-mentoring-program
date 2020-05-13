using System;
using System.Collections.Generic;
using System.Text;

namespace MentoringDataAccess.Interfaces
{
    public interface IShapeRepository
    {
        public string ReadShape(string shapeName);
    }
}
