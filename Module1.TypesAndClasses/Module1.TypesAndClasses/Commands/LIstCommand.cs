using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Services;
using System;
using System.Collections.Generic;

namespace Module1.TypesAndClasses.Commands
{
    class ListCommand : IInputCommand
    {
        readonly List<string> ShapesTypes = new List<string>
        {
            "c", "e", "r", "t"
        };

        private readonly ShapesService _shapeService;
        private readonly string[] _inputParameters;
        private readonly string _instruction;

        public ListCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
            if (_inputParameters.Length < 3)
            {
                throw new Exception("Incorrect usage of 'list' command. Put 'help list' to see example.");
            }
            _shapeService  = new ShapesService();
            _instruction = _inputParameters[2];
        }

        public string Execute()
        {
            if(_instruction == null)
            {
                throw new ArgumentNullException(nameof(_instruction));
            }

            return _instruction switch
            {
                "c" => $"{Environment.NewLine}{_shapeService.ReadShapeExample(ShapeTypes.Circle)} {Environment.NewLine}",
                "e" => $"{Environment.NewLine}{_shapeService.ReadShapeExample(ShapeTypes.Ellipse)} {Environment.NewLine}",
                "r" => $"{Environment.NewLine}{_shapeService.ReadShapeExample(ShapeTypes.Rectangle)} {Environment.NewLine}",
                "t" => $"{Environment.NewLine}{_shapeService.ReadShapeExample(ShapeTypes.EquilateralTriangle)} {Environment.NewLine}",
                _ => throw new Exception($"Supported shapes - {string.Join(", ", ShapesTypes)}"),
            };
        }

        public string Validate()
        {
            if (!(_inputParameters.Length == 3))
            {
                return $"Incorrect usage of 'list' command. {Environment.NewLine}" +
                    "Example: list -json-example c.";
            }

            if (!(_inputParameters[1] == "-json-example"))
            {
                return $"Incorrect usage of 'list' command: '{_inputParameters[1]}' is not recognized as an option. {Environment.NewLine}" +
                    "Example: list -json-example c.";
            }

            if (!ShapesTypes.Contains(_inputParameters[2]))
            {
                return $"Not supported argument '{_inputParameters[2]}'. Supported shapes - {string.Join(", ", ShapesTypes)}.";
            }

            if (_inputParameters[1] == null)
            {
                return $"Incorrect usage of 'list' command: the option '-json-example' was not provided. {Environment.NewLine}" +
                    "Example: list -json-example c.";
            }

            return string.Empty;
        }
    }
}
