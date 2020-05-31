using Module1.TypesAndClasses.Commands;
using System;

namespace Module1.TypesAndClasses.Factories
{
    class CommandsFactory
    {
        private readonly string[] _commandParams;

        public CommandsFactory(string[] commandParams)
        {
            _commandParams = commandParams ?? throw new ArgumentNullException(nameof(commandParams));
        }

        public IInputCommand Create(string commandName)
        {
            switch (commandName)
            {
                case "list":
                    return new LIstCommand(_commandParams);

                case "import":
                    return new ImportCommand(_commandParams);

                /*case "export":
                    var exportCommand = new ExportCommand(parameters);
                    string exportValidationMessage = exportCommand.Validate();

                    if (!string.IsNullOrEmpty(exportValidationMessage))
                    {
                        Console.WriteLine(exportValidationMessage);

                        break;
                    }

                    Console.WriteLine(exportCommand.Execute(parameters[1]) ?? $"Command '{commandName}' executed.");

                    break;

                case "help":
                    var helpCommand = new HelpCommand(parameters);
                    string helpValidationMessage = helpCommand.Validate();

                    if (!string.IsNullOrEmpty(helpValidationMessage))
                    {
                        Console.WriteLine(helpValidationMessage);

                        break;
                    }

                    Console.WriteLine(helpCommand.Execute(string.Join(" ", parameters)) ?? $"Command '{commandName}' executed.");

                    break;
                    */
                default:
                    throw new NotSupportedException($"Unknown command name: '{commandName}'");                    
                    //return null;
            }
        }
    }
}
