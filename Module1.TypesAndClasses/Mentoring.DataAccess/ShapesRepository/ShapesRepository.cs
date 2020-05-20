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
        // cr: please remove
        //private List<string> ResourceNames = new List<string>()
        //{
        //    "Mentoring.DataAccess.circle.json",
        //    "Mentoring.DataAccess.ellipse.json",
        //    "Mentoring.DataAccess.equilateraltriangle.json",
        //    "Mentoring.DataAccess.rectangle.json"
        //};

        // cr: is not needed, please remove
        public ShapesRepository() {}

        public string ReadShape(string shapeName)
        {
            if (!shapeName.EndsWith(".json"))
            {
                throw new NotSupportedException($"The file format is not supported: '{shapeName}'");
            }

            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames();

            // cr: please remove the cycle as we discussed on the meeting
            foreach (string resourceName in resourceNames)
            {
                if (resourceName.EndsWith(shapeName.ToLower()))
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
                // cr: and this as well:
                //else
                //{
                //    throw new NotSupportedException();
                //}
            }
            // cr: let's rearrange it
            throw new FileNotFoundException("Cannot find '{shapeName}' of type json in assets!"); 
        }
    }
}
