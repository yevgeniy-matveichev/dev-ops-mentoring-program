using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Exceptions;
using Module1.TypesAndClasses.Pools;
using System;
using System.Collections.Generic;

namespace Module1.TypesAndClasses.Commands
{
    public class ListCommand : IInputCommand
    {
        readonly List<string> ShapesTypes = new List<string>
        {
            "c", "e", "r", "t"
        };

        private readonly ShapeServicePool _shapeServiceFactory;

        public ListCommand(ShapeServicePool shapeServiceFactory)
        {
            _shapeServiceFactory = shapeServiceFactory ?? throw new ArgumentNullException(nameof(shapeServiceFactory));
        }

        public string Name => nameof(ListCommand);

        public string Execute(string[] inputParameters)
        {
            var instruction = inputParameters[2];

            if (instruction == null)
            {
                throw new ArgumentNullException(nameof(instruction));
            }

            return instruction switch
            {
                "c" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Circle).ReadShapeExample()} {Environment.NewLine}",
                "e" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Ellipse).ReadShapeExample()} {Environment.NewLine}",
                "r" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.Rectangle).ReadShapeExample()} {Environment.NewLine}",
                "t" => $"{Environment.NewLine}{_shapeServiceFactory.Create(ShapeTypes.EquilateralTriangle).ReadShapeExample()} {Environment.NewLine}",
                _ => throw new ShapeTypeNotFoundException($"Supported shapes - {string.Join(", ", ShapesTypes)}"),
            };
        }

        public string Validate(string[] inputParameters)
        {
            if (inputParameters == null)
            {
                throw new ArgumentNullException(nameof(inputParameters));
            }

            if (inputParameters.Length < 3)
            {
                throw new InvalidCommandUsageException("Incorrect usage of 'list' command. Put 'help list' to see example.");
            }
            

            if (!(inputParameters.Length == 3))
            {
                throw new InvalidCommandUsageException($"Incorrect usage of 'list' command. {Environment.NewLine}" +
                    "Example: list -json-example c.");
            }

            if (!(inputParameters[1] == "-json-example"))
            {
                throw new InvalidCommandUsageException($"Incorrect usage of 'list' command: '{inputParameters[1]}' " +
                    $"is not recognized as an option. {Environment.NewLine}Example: list -json-example c.");
            }

            if (!ShapesTypes.Contains(inputParameters[2]))
            {
                throw new InvalidCommandUsageException($"Not supported argument '{inputParameters[2]}'. Supported shapes - {string.Join(", ", ShapesTypes)}.");
            }

            if (inputParameters[1] == null)
            {
                throw new InvalidCommandUsageException($"Incorrect usage of 'list' command: the option '-json-example' was not provided. " +
                    $"{Environment.NewLine}Example: list -json-example c.");
            }

            return string.Empty;
        }
    }
}
