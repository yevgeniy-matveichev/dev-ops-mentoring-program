using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.DataAccess.Interfaces
{
    public interface IShapeRepository
    {
        public string ReadShape(string shapeName);
    }
}
