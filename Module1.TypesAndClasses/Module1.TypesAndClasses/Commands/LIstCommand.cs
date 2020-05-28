using Mentoring.DataAccess.ShapesRepository;
using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Services;
using System;
using System.Text;

namespace Module1.TypesAndClasses.Commands
{
    class ListCommand : IInputCommand
    {
        private readonly ShapesService _shapeService;
        private readonly string[] _inputParameters;

        public ListCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
            _shapeService  = new ShapesService(new ShapesRepository());
        }

        public string Execute()
        {
            string result = "";

            /* todo: fix this
            switch (instruction)
            {
                case "c":
                    result = $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.Circle)} {Environment.NewLine}";

                    break;

                case "e":
                    result = $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.Ellipse)} {Environment.NewLine}";

                    break;

                case "r":
                    result = $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.Rectangle)} {Environment.NewLine}";

                    break;

                case "t":
                    result = $"{Environment.NewLine}{_shapeService.ReadShape(ShapeTypes.EquilateralTriangle)} {Environment.NewLine}";

                    break;

                default:
                    Console.WriteLine($"Not supported argument - {option}"); // cr: throw NotSupportedException
                    break;
            }

            */

            return result;
        }

        public string Validate()
        {
            if (!(_inputParameters.Length == 3))
            {
                Console.WriteLine($"Incorrect usage of 'list' command. {Environment.NewLine}" +
                    "Example: list -json-example c.");
                // cr: return message instead of Console.Writeline
            }

            if (!(_inputParameters[1] == "-json-example"))
            {
                Console.WriteLine($"Incorrect usage of 'list' command: '{_inputParameters[1]}' is not recognized as an option. {Environment.NewLine}" +
                    "Example: list -json-example c.");

                // cr: return message instead of Console.Writeline
            }

            /* todo: fix thisand uncomment
            if (!supportedShapes.Contains(_inputParameters[2]))
            {
                Console.WriteLine($"Not supported argument - {_inputParameters[2]}");
            }
            */

            return string.Empty;
        }
    }
}
