using Mentoring.DataAccess.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Mentoring.DataAccess.ShapesRepository
{
    public class ShapesRepository<T> : IShapeRepository<T> where T: class
    {
        public ShapesRepository() {}

        public void WriteShape(string filePath, T modelType)
        {
            if (File.Exists(filePath))
            {
                //Implement saving shapes to disk. 
            }

            //The method should have the path to the file as input parameter and the shape model. 
        }

        public T ReadShape(string shapeName)
        {
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
                            T model = JsonConvert.DeserializeObject<T>(result);

                            return model;
                        }
                    }
                }
            }
            // cr: let's rearrange it
            throw new FileNotFoundException($"Cannot find '{shapeName}' of type json in assets!");
        }
    }
}