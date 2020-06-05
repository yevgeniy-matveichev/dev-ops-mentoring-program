using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Module1.TypesAndClasses.Commands
{
    class ExportCommand : IInputCommand
    {
        readonly List<string> Commands = new List<string>
        {
            "-path", "-shapeType"
        };

        readonly List<string> ShapesTypes = new List<string>
        {
            "c", "e", "r", "t"
        };

        private readonly string[] _inputParameters;
        private readonly string _path;
        private readonly string _shapeType;
        private readonly ShapesService _shapeService;

        public ExportCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
            if (_inputParameters.Length < 4) throw new Exception("Incorrect usage of 'export' command. Put 'help export' to see example.");
            if (_inputParameters.Contains(Commands[0])) _path = _inputParameters[Array.IndexOf(_inputParameters, "-path") + 1];
            if (_inputParameters.Contains(Commands[1])) _shapeType = _inputParameters[Array.IndexOf(_inputParameters, "-shapeType") + 1];
            _shapeService = new ShapesService();
        }

        public string Execute()
        {
            return "Method is not implemented.";
            /*if (_shapeType == null)
            {
                throw new ArgumentNullException(nameof(_shapeType));
            }

            return _shapeType switch
            {
                "c" => $"{Environment.NewLine}{_shapeService.WriteShape(_path, ShapeTypes.Circle)} {Environment.NewLine}",
                "e" => $"{Environment.NewLine}{_shapeService.WriteShape(_path, ShapeTypes.Ellipse)} {Environment.NewLine}",
                "r" => $"{Environment.NewLine}{_shapeService.WriteShape(_path, ShapeTypes.Rectangle)} {Environment.NewLine}",
                "t" => $"{Environment.NewLine}{_shapeService.WriteShape(_path, ShapeTypes.EquilateralTriangle)} {Environment.NewLine}",
                _ => throw new Exception($"Supported shapes - {string.Join(", ", ShapesTypes)}"),
            };*/
        }

        public string Validate()
        {
            if (!(_inputParameters.Length == 4))
            {
                return $"Incorrect usage of 'export' command. {Environment.NewLine}" +
                    "Example: export -shapeName circle -path D:\\temp\\circle.json.";
            }

            if (!_inputParameters.Contains(Commands[0]))
            {
                return $"Incorrect usage of 'export' command: the path was not provided. {Environment.NewLine}" +
                    "Example: export -shapeName circle -path D:\\temp\\circle.json";
            }

            if (!_inputParameters.Contains(Commands[1]))
            {
                return $"Incorrect usage of 'export' command: the shape name was not provided. {Environment.NewLine}" +
                    "Example: export -shapeName circle -path D:\\temp\\circle.json";
            }

            if (!File.Exists(_path.Substring(0, _path.LastIndexOf("\\") + 1)))
            {
                return $"The path '{_path.Substring(0, _path.LastIndexOf("\\") + 1)} does not exist.'";
            }

            if (!_path.EndsWith(".json"))
            {
                return $"Incorrect file extension provided - {_inputParameters[2]}. Must be .json.";
            }

            return string.Empty;
        }
    }
}