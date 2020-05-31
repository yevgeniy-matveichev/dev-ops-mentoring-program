using Mentoring.DataAccess.ShapesRepository;
using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Commands
{
    class LIstCommand : IInputCommand
    {
        readonly List<string> SupportedShapes = new List<string>
        {
            "c", "e", "r", "t"
        };

        private readonly ShapesService _shapeService;
        private readonly string[] _inputParameters;

        public LIstCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
            _shapeService  = new ShapesService(new ShapesRepository());
        }

        public string Execute(string instruction)
        {
            if(instruction == null)
            {
                throw new ArgumentNullException(nameof(instruction));
            }

            var result = instruction switch
            {
                "c" => $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.Circle)} {Environment.NewLine}",
                "e" => $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.Ellipse)} {Environment.NewLine}",
                "r" => $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.Rectangle)} {Environment.NewLine}",
                "t" => $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.EquilateralTriangle)} {Environment.NewLine}",
                _ => throw new NotSupportedException(nameof(instruction)),
            };
            return result;
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

            return string.Empty;
        }
    }
}
