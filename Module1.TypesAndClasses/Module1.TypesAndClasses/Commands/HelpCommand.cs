using Module1.TypesAndClasses.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Commands
{
    public class HelpCommand : IInputCommand
    {
        public readonly Dictionary<string, string> CommandsDescription = new Dictionary<string, string>()
        {
            { "help", $"Describes Shapes program commands.{Environment.NewLine}\t\tExample: help list{Environment.NewLine}\t\tExample: help" },
            { "list", $"Shows the example of the shape.{Environment.NewLine}\t\tExample: list -json-example c" },
            { "import", $"Imports the shape from the path.{Environment.NewLine}\t\tExample: import -path D:\\temp\\file.json -shapeType c" },
            { "export", $"Exports the shape to JSON file, saves the file to specified path.{Environment.NewLine}\t\tExample: export -path D:\\temp\\circle.json -shapeType c" },
            { "exit", "Exits the Shapes program." }
        };

        public HelpCommand()
        {
            
        }

        public string Name => nameof(HelpCommand);

        public string Execute(string[] inputParameters)
        {
            string result;

            StringBuilder sb = new StringBuilder();

            if (inputParameters.Length == 1) 
            {
                foreach(var command in CommandsDescription.Keys)
                {
                    sb.Append($"{command}\t\t{CommandsDescription[command]}{Environment.NewLine}");
                }

                result = sb.ToString();
            }
            else
            {
                result = (inputParameters[1]) switch
                {
                    "help" => $"help\t\t{CommandsDescription["help"]}",
                    "list" => $"list\t\t{CommandsDescription["list"]}",
                    "import" => $"import\t\t{CommandsDescription["import"]}",
                    "export" => $"export\t\t{CommandsDescription["export"]}",
                    "exit" => $"exit\t\t{CommandsDescription["exit"]}",
                    _ => throw new CommandNotFoundException(nameof(inputParameters)),
                };
            }

            return result;
        }

        public string Validate(string[] inputParameters)
        {
            if (inputParameters == null)
            {
                throw new ArgumentNullException(nameof(inputParameters));
            }

            if (inputParameters.Length > 2)
            {
                throw new InvalidCommandUsageException($"Incorrect usage of 'help' command: '{string.Join(" ", inputParameters)}'." +
                    $"{Environment.NewLine}Example: 'help list' or 'help'.");
            }

            if (inputParameters.Length == 2)
            {
                if (!CommandsDescription.ContainsKey(inputParameters[1]))
                {
                    throw new InvalidCommandUsageException($"Incorrect usage of 'help' command: '{inputParameters[1]}' " +
                        $"is not recognized as an option. {Environment.NewLine}Example: 'help list' or 'help'.");
                }
            }

            return string.Empty;
        }
    }
}
