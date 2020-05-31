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
            "-path", "-shapeName"
        };

        readonly List<string> ShapesNames = new List<string>
        {
            "circle", "ellipse", "rectangle", "equilateraltriangle"
        };

        private readonly string[] _inputParameters;
        private readonly string _path;
        private readonly string _shapeName;

        public ExportCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
            if(_inputParameters.Contains(Commands[0])) _path = _inputParameters[Array.IndexOf(_inputParameters, "-path") + 1];
            if (_inputParameters.Contains(Commands[1])) _shapeName = _inputParameters[Array.IndexOf(_inputParameters, "-shapeName") + 1];
        }

        public string Execute()
        {
            return "Method is not implemented.";
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