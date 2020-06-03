using Mentoring.DataAccess.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Mentoring.DataAccess.ShapesRepository
{
    public class ShapesRepository<T> : IShapeRepository<T> where T : class
    {
        public ShapesRepository() { }

        public void WriteShape(string filePath, T model)
        {
            if (File.Exists(filePath))
            {
                throw new Exception($"File '{filePath}' already exists!");                
            }

            //Implement saving shapes to disk. 
            string objectContent = JsonConvert.SerializeObject(model);
            using (FileStream fs = File.Create(filePath))
            {
                File.WriteAllText(filePath, objectContent);
            }
        }

        public T ReadShape(string shapeName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            if (!shapeName.ToLower().EndsWith(".json"))
            {
                throw new NotSupportedException($"Cannot process file '{shapeName}' which is not a type of json!");
            }

            using (Stream stream = assembly.GetManifestResourceStream($"Mentoring.DataAccess.Assets.{shapeName.ToLower()}"))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException($"Cannot find '{shapeName}' of type json in assets!");
                }
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();
                    T model = JsonConvert.DeserializeObject<T>(result);

                    return model;
                }
            }
        }
    }
}