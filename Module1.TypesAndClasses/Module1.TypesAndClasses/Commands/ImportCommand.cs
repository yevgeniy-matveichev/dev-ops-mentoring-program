using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Module1.TypesAndClasses.Commands
{
    class ImportCommand : IInputCommand
    {
        readonly List<string> Commands = new List<string>
        {
            "-path", "-shapeType"
        };

        readonly List<string> ShapesTypes = new List<string>
        {
            "c", "e", "r", "t"
        };

        #region private fields

        private readonly string[] _inputParameters;
        private readonly string _path;
        private readonly string _shapeType;
        private readonly ShapeServiceFactory _shapeServiceFactory;

        #endregion

        public ImportCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
            if (_inputParameters.Length < 4)
            {
                throw new Exception("Incorrect usage of 'import' command. Put 'help import' to see example.");
            }
            if (_inputParameters.Contains(Commands[0]))
            {
                _path = _inputParameters[Array.IndexOf(_inputParameters, "-path") + 1];
            }
            if (_inputParameters.Contains(Commands[1]))
            {
                _shapeType = _inputParameters[Array.IndexOf(_inputParameters, "-shapeType") + 1];
            }

            _shapeServiceFactory = new ShapeServiceFactory();
        }

        public string Execute()
        {
            if (_shapeType == null)
            {
                throw new ArgumentNullException(nameof(_shapeType));
            }

            return _shapeType switch
            {
                "c" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Circle).ReadShape(_path)} {Environment.NewLine}",
                "e" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Ellipse).ReadShape(_path)} {Environment.NewLine}",
                "r" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Rectangle).ReadShape(_path)} {Environment.NewLine}",
                "t" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.EquilateralTriangle).ReadShape(_path)} {Environment.NewLine}",
                _ => throw new Exception($"Supported shapes - {string.Join(", ", ShapesTypes)}"),
            };
        }

        public string Validate()
        {
            if (!(_inputParameters.Length == 5))
            {
                return $"Incorrect usage of 'import' command. {Environment.NewLine}" +
                    "Example: import -path D:\\temp\\file.json -shapeType c.";
            }

            if (!(_inputParameters[1] == "-path"))
            {
                return $"Incorrect usage of 'import' command: '{_inputParameters[1]}' is not recognized as an option. {Environment.NewLine}" +
                    "Example: import -path D:\\temp\\file.json -shapeType c.";
            }

            if (!File.Exists(_inputParameters[2]))
            {
                return $"File {_inputParameters[2]} does not exist.";
            }

            if (!_inputParameters[2].EndsWith(".json"))
            {
                return $"Incorrect file extension provided - {_inputParameters[2]}. Must be .json.";
            }

            return string.Empty;
        }
    }
}
