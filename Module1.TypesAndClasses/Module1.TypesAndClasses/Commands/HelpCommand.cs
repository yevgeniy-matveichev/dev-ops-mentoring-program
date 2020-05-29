using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Commands
{
    class HelpCommand : IInputCommand
    {
        private readonly string[] _inputParameters;

        public readonly Dictionary<string, string> CommandsDescription = new Dictionary<string, string>()
        {
            { "help", "Describes Shapes program commands." },
            { "list", "Shows the example of the shape." },
            { "import", "Imports the shape from the path." },
            { "export", "Exports the shape to JSON file, saves the file to specified path." },
            { "exit", "Exists the Shapes program." }
        };

        public HelpCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
        }

        public string Execute(string instruction)
        {
            if (instruction == null)
            {
                throw new ArgumentNullException(nameof(instruction));
            }

            string result = string.Empty;

            if (instruction.Split().Length == 1) 
            {
                foreach(var command in CommandsDescription.Keys)
                {
                    Console.WriteLine($"{command}\t\t{CommandsDescription[command]}");
                }
            }
            else
            {
                result = (instruction.Split()[1]) switch
                {
                    "help" => $"help\t\t{CommandsDescription["help"]}",
                    "list" => $"list\t\t{CommandsDescription["list"]}",
                    "import" => $"import\t\t{CommandsDescription["import"]}",
                    "export" => $"export\t\t{CommandsDescription["export"]}",
                    "exit" => $"exit\t\t{CommandsDescription["exit"]}",
                    _ => throw new NotSupportedException(nameof(instruction)),
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

            return string.Empty;
        }
    }
}
