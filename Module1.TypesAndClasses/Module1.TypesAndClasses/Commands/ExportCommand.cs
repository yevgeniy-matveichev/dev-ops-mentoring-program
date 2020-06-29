﻿using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Module1.TypesAndClasses.Commands
{
    public class ExportCommand : IInputCommand
    {
        readonly List<string> Commands = new List<string>
        {
            "-path", "-shapeType"
        };

        readonly List<string> ShapesTypes = new List<string>
        {
            "c", "e", "r", "t"
        };

        private readonly ShapeServiceFactory _shapeServiceFactory;

        public ExportCommand()
        {
            _shapeServiceFactory = new ShapeServiceFactory();
        }

        public string Name => nameof(ExportCommand);

        public string Execute(string[] inputParameters)
        {
            return "Method is not implemented.";

            //var path = string.Empty;
            //if (inputParameters.Contains(Commands[0]))
            //{
            //    path = inputParameters[Array.IndexOf(inputParameters, "-path") + 1];
            //}

            //var shapeType = string.Empty;
            //if (inputParameters.Contains(Commands[1]))
            //{
            //    shapeType = inputParameters[Array.IndexOf(inputParameters, "-shapeType") + 1];
            //}

            //return shapeType switch
            //{
            //    "c" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Circle).WriteShape(path, shapeType)} {Environment.NewLine}",
            //    "e" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Ellipse).WriteShape(path, shapeType)} {Environment.NewLine}",
            //    "r" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Rectangle).WriteShape(path, shapeType)} {Environment.NewLine}",
            //    "t" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.EquilateralTriangle).WriteShape(path, shapeType)} {Environment.NewLine}",
            //    _ => throw new Exception($"Supported shapes - {string.Join(", ", ShapesTypes)}"),
            //};
        }

        public string Validate(string[] inputParameters)
        {
            if (inputParameters == null)
            {
                throw new ArgumentNullException(nameof(inputParameters));
            }

            if (inputParameters.Length < 4)
            {
                throw new Exception("Incorrect usage of 'export' command. Put 'help export' to see example.");
            }
            
            if (!(inputParameters.Length == 5))
            {
                return $"Incorrect usage of 'export' command. {Environment.NewLine}" +
                    "Example: export -path D:\\temp\\circle.json -shapeType c.";
            }

            if (!inputParameters.Contains(Commands[0]))
            {
                return $"Incorrect usage of 'export' command: the path was not provided. {Environment.NewLine}" +
                    "Example: export -path D:\\temp\\circle.json -shapeType c";
            }

            if (!inputParameters.Contains(Commands[1]))
            {
                return $"Incorrect usage of 'export' command: the shape name was not provided. {Environment.NewLine}" +
                    "Example: export -path D:\\temp\\circle.json -shapeType c";
            }

            //if (!File.Exists(_path.Substring(0, _path.LastIndexOf("\\") + 1)))
            //{
            //    return $"The path '{_path.Substring(0, _path.LastIndexOf("\\") + 1)} does not exist.'";
            //}

            //if (!_path.EndsWith(".json"))
            //{
            //    return $"Incorrect file extension provided - {inputParameters[2]}. Must be .json.";
            //}

            return string.Empty;
        }
    }
}