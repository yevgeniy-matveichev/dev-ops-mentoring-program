using Mentoring.DataAccess.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

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

        public async void WriteShapeAsync(string filePath, T model)
        {
            if (File.Exists(filePath))
            {
                throw new Exception($"File '{filePath}' already exists!");
            }

            //Implement saving shapes to disk. 
            string objectContent = JsonConvert.SerializeObject(model);
            using (FileStream fs = File.Create(filePath))
            {
                await File.WriteAllTextAsync(filePath, objectContent);
            }
        }

        public T ReadShape(string shapeFilePath)
        {
            if (!shapeFilePath.ToLower().EndsWith(".json"))
            {
                throw new NotSupportedException($"Cannot process file '{shapeFilePath}' which is not a type of json!");
            }

            if (File.Exists(shapeFilePath))
            {
                using (FileStream fs = File.OpenRead(shapeFilePath))
                {
                    string result = File.ReadAllText(shapeFilePath);
                    T model = JsonConvert.DeserializeObject<T>(result);

                    return model;
                }
            }
            else
            {
                throw new Exception($"File '{shapeFilePath}' does not exist!");
            }
        }


        public async Task<T> ReadShapeAsync(string shapeFilePath)
        {
            if (!shapeFilePath.ToLower().EndsWith(".json"))
            {
                throw new NotSupportedException($"Cannot process file '{shapeFilePath}' which is not a type of json!");
            }

            if (File.Exists(shapeFilePath))
            {
                using (FileStream fs = File.OpenRead(shapeFilePath))
                {
                    string result = await File.ReadAllTextAsync(shapeFilePath);
                    T model = JsonConvert.DeserializeObject<T>(result);

                    return model;
                }
            }
            else
            {
                throw new Exception($"File '{shapeFilePath}' does not exist!");
            }
        }

        public T ReadShapeExample(string shapeName)
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

        public async Task<T> ReadShapeExampleAsync(string shapeName)
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
                    string result = await reader.ReadToEndAsync();
                    T model = JsonConvert.DeserializeObject<T>(result);

                    return model;
                }
            }
        }
    }
}