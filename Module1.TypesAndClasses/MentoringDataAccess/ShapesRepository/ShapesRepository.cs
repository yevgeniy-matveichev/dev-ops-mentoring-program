using MentoringDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MentoringDataAccess.ShapesRepository
{
    public class ShapesRepository : IShapeRepository
    {

        public string ReadShape(string shapeName)
        {
            //TODO: implement read the embedded resources

            return $"shape '{shapeName}' is recieved";
        }

    }
}
