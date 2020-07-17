using log4net;
using Module1.TypesAndClasses.Exceptions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Module1.TypesAndClasses.Commands
{
    public class HelpCommand : IInputCommand
    {
        private readonly ILog _log;

        public readonly Dictionary<string, string> CommandsDescription = new Dictionary<string, string>()
        {
            { "help", $"Describes Shapes program commands.{Environment.NewLine}\t\tExample: help list{Environment.NewLine}\t\tExample: help" },
            { "list", $"Shows the example of the shape.{Environment.NewLine}\t\tExample: list -json-example c" },
            { "import", $"Imports the shape from the path.{Environment.NewLine}\t\tExample: import -path D:\\temp\\file.json -shapeType c" },
            { "export", $"Exports the shape to JSON file, saves the file to specified path.{Environment.NewLine}\t\tExample: export -path D:\\temp\\circle.json -shapeType c" },
            { "exit", "Exits the Shapes program." }
        };

        public HelpCommand(ILog log)
        {
            _log = log; 
        }

        public string Name => nameof(HelpCommand);

        public string Execute(string[] inputParameters)
        {
            string result;

            StringBuilder sb = new StringBuilder();

            if (inputParameters.Length == 1)
            {
                foreach (var command in CommandsDescription.Keys)
                {
                    sb.Append($"{command}\t\t{CommandsDescription[command]}{Environment.NewLine}");
                }

                result = sb.ToString();
                return result;
            }
            else
            {
                switch (inputParameters[1])
                {
                    case "help":
                        {
                            return $"help\t\t{CommandsDescription["help"]}";
                        }
                    case "list":
                        {
                            return $"list\t\t{CommandsDescription["list"]}";
                        }
                    case "import":
                        {
                            return $"import\t\t{CommandsDescription["import"]}";
                        }
                    case "export":
                        {
                            return $"export\t\t{CommandsDescription["export"]}";
                        }
                    case "exit":
                        {
                            return $"exit\t\t{CommandsDescription["exit"]}";
                        }
                    default:
                        {
                            throw new CommandNotFoundException(nameof(inputParameters));
                        }
                }
            };
        }

        public string Validate(string[] inputParameters)
        {
            if (inputParameters == null)
            {
                throw new ArgumentNullException(nameof(inputParameters));
            }

            if (inputParameters.Length > 2)
            {
                _log.Error($"InvalidCommandUsageException({string.Join(" ", inputParameters)})");
                throw new InvalidCommandUsageException($"Incorrect usage of 'help' command: '{string.Join(" ", inputParameters)}'." +
                    $"{Environment.NewLine}Example: 'help list' or 'help'.");
            }

            if (inputParameters.Length == 2)
            {
                if (!CommandsDescription.ContainsKey(inputParameters[1]))
                {
                    _log.Error($"InvalidCommandUsageException({string.Join(' ', inputParameters)})");
                    throw new InvalidCommandUsageException($"Incorrect usage of 'help' command: '{inputParameters[1]}' " +
                        $"is not recognized as an option. {Environment.NewLine}Example: 'help list' or 'help'.");
                }
            }

            return string.Empty;
        }
    }
}
