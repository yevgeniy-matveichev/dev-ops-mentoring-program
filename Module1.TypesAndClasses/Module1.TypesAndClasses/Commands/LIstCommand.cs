using Mentoring.DataAccess.ShapesRepository;
using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Services;
using System;
using System.Collections.Generic;

namespace Module1.TypesAndClasses.Commands
{
    class ListCommand : IInputCommand
    {
        readonly List<string> SupportedShapes = new List<string>
        {
            "c", "e", "r", "t"
        };

        private readonly ShapesService _shapeService;
        private readonly string[] _inputParameters;
        private readonly string _instruction;

        public ListCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
            _shapeService  = new ShapesService();

            //if(_inputParameters.Length < 3) throw new ArgumentNullException(nameof(inputParameters));
            if (_inputParameters.Length < 3) throw new ArgumentNullException("-json-example");
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
                "c" => $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.Circle)} {Environment.NewLine}",
                "e" => $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.Ellipse)} {Environment.NewLine}",
                "r" => $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.Rectangle)} {Environment.NewLine}",
                "t" => $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.EquilateralTriangle)} {Environment.NewLine}",
                _ => throw new NotSupportedException(nameof(_instruction)),
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

            if (!SupportedShapes.Contains(_inputParameters[2]))
            {
                return $"Not supported argument - {_inputParameters[2]}";
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
