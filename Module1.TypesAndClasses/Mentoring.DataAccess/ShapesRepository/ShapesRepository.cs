using Mentoring.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Mentoring.DataAccess.ShapesRepository
{
    public class ShapesRepository : IShapeRepository
    {
        //private List<string> ResourceNames = new List<string>()
        //{
        //    "Mentoring.DataAccess.circle.json",
        //    "Mentoring.DataAccess.ellipse.json",
        //    "Mentoring.DataAccess.equilateraltriangle.json",
        //    "Mentoring.DataAccess.rectangle.json"
        //};

        public ShapesRepository() {}

        public string ReadShape(string shapeName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames();

            foreach (string resourceName in resourceNames)
            {
                if (resourceName.EndsWith(shapeName.ToLower() + ".json"))
                {
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string result = reader.ReadToEnd();
                            return result;
                        }
                    }
                }
                //else
                //{
                //    throw new NotSupportedException();
                //}
            }
            throw new FileNotFoundException("Cannot find '{shapeName}' of type json in assets!"); 
        }
    }
}
