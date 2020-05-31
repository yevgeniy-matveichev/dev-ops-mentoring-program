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
            return commandName switch
            {
                "list" => new ListCommand(_commandParams),
                "import" => new ImportCommand(_commandParams),
                "export" => new ExportCommand(_commandParams),
                "help" => new HelpCommand(_commandParams),
                _ => throw new NotSupportedException($"Unknown command name: '{commandName}'"),
            };
        }
    }
}
