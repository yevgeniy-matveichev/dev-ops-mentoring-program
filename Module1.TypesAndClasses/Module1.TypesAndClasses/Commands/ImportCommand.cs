using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Pools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Module1.TypesAndClasses.Commands
{
    public class ImportCommand : IInputCommand
    {
        readonly List<string> Commands = new List<string>
        {
            "-path", "-shapeType"
        };

        readonly List<string> ShapesTypes = new List<string>
        {
            "c", "e", "r", "t"
        };

        private readonly ShapeServicePool _shapeServiceFactory;

        public ImportCommand(ShapeServicePool shapeServiceFactory)
        {
            _shapeServiceFactory = shapeServiceFactory ?? throw new ArgumentNullException(nameof(shapeServiceFactory));
        }

        public string Name => nameof(ImportCommand);

        public string Execute(string[] inputParameters)
        {
            var path = string.Empty;
            if (inputParameters.Contains(Commands[0]))
            {
                path = inputParameters[Array.IndexOf(inputParameters, "-path") + 1];
            }

            var shapeType = string.Empty;
            if (inputParameters.Contains(Commands[1]))
            {
                shapeType = inputParameters[Array.IndexOf(inputParameters, "-shapeType") + 1];
            }

            return shapeType switch
            {
                "c" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Circle).ReadShape(path)} {Environment.NewLine}",
                "e" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Ellipse).ReadShape(path)} {Environment.NewLine}",
                "r" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Rectangle).ReadShape(path)} {Environment.NewLine}",
                "t" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.EquilateralTriangle).ReadShape(path)} {Environment.NewLine}",
                _ => throw new Exception($"Supported shapes - {string.Join(", ", ShapesTypes)}"),
            };
        }

        public string Validate(string[] inputParameters)
        {
            if (inputParameters == null)
            {
                throw new ArgumentNullException(nameof(inputParameters));
            }

            if (inputParameters.Length < 4)
            {
                throw new Exception("Incorrect usage of 'import' command. Put 'help import' to see example.");
            }

            if (!(inputParameters.Length == 5))
            {
                return $"Incorrect usage of 'import' command. {Environment.NewLine}" +
                    "Example: import -path D:\\temp\\file.json -shapeType c.";
            }

            if (!(inputParameters[1] == "-path"))
            {
                return $"Incorrect usage of 'import' command: '{inputParameters[1]}' is not recognized as an option. {Environment.NewLine}" +
                    "Example: import -path D:\\temp\\file.json -shapeType c.";
            }

            if (!File.Exists(inputParameters[2]))
            {
                return $"File {inputParameters[2]} does not exist.";
            }

            if (!inputParameters[2].EndsWith(".json"))
            {
                return $"Incorrect file extension provided - {inputParameters[2]}. Must be .json.";
            }

            return string.Empty;
        }
    }
}
