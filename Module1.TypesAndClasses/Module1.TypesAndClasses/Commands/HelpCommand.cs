using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Commands
{
    class HelpCommand : IInputCommand
    {
        private readonly string[] _inputParameters;
        //private readonly string _instruction;

        public readonly Dictionary<string, string> CommandsDescription = new Dictionary<string, string>()
        {
            { "help", "Describes Shapes program commands." },
            { "list", "Shows the example of the shape." },
            { "import", "Imports the shape from the path." },
            { "export", "Exports the shape to JSON file, saves the file to specified path." },
            { "exit", "Exits the Shapes program." }
        };

        public HelpCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
            //if (_inputParameters.Length == 2) _instruction = _inputParameters[1];
        }

        public string Execute()
        {
            //if (_instruction == null)
            //{
            //    throw new ArgumentNullException(nameof(_instruction));
            //}

            string result = string.Empty;

            //var sb = new StringBuilder();

            if (_inputParameters.Length == 1) 
            {
                foreach(var command in CommandsDescription.Keys)
                {
                    Console.WriteLine($"{command}\t\t{CommandsDescription[command]}");
                    //sb.Append($"{command}\t\t{CommandsDescription[command]}");
                }
                //result = sb.ToString();
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
