using System;
using System.Collections.Generic;

namespace Module1.TypesAndClasses.Commands
{
    public class HelpCommand : IInputCommand
    {
        private readonly string[] _inputParameters;

        public readonly Dictionary<string, string> CommandsDescription = new Dictionary<string, string>()
        {
            { "help", $"Describes Shapes program commands.{Environment.NewLine}\t\tExample: help list" },
            { "list", $"Shows the example of the shape.{Environment.NewLine}\t\tExample: list -json-example c" },
            { "import", $"Imports the shape from the path.{Environment.NewLine}\t\tExample: import -path D:\\temp\\file.json -shapeType c" },
            { "export", $"Exports the shape to JSON file, saves the file to specified path.{Environment.NewLine}\t\tExample: export -path D:\\temp\\circle.json -shapeType c" },
            { "exit", "Exits the Shapes program." }
        };

        public HelpCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
        }

        public string Execute()
        {
            string result = string.Empty;

            if (_inputParameters.Length == 1) 
            {
                foreach(var command in CommandsDescription.Keys)
                {
                    Console.WriteLine($"{command}\t\t{CommandsDescription[command]}");
                }
            }
            else
            {
                result = (_inputParameters[1]) switch
                {
                    "help" => $"help\t\t{CommandsDescription["help"]}",
                    "list" => $"list\t\t{CommandsDescription["list"]}",
                    "import" => $"import\t\t{CommandsDescription["import"]}",
                    "export" => $"export\t\t{CommandsDescription["export"]}",
                    "exit" => $"exit\t\t{CommandsDescription["exit"]}",
                    _ => throw new NotSupportedException(nameof(_inputParameters)),
                };
            }

            return result;
        }

        public string Validate()
        {
            if(_inputParameters.Length > 2)
            {
                return $"Incorrect usage of 'help' command: '{_inputParameters}'. {Environment.NewLine}" +
                    "Example: help list.";
            }

            if(_inputParameters.Length == 2)
            {
                if (!CommandsDescription.ContainsKey(_inputParameters[1]))
                {
                    return $"Incorrect usage of 'help' command: '{_inputParameters}' is not recognized as an option. {Environment.NewLine}" +
                        "Example: help list.";
                }
            }

            return string.Empty;
        }
    }
}
