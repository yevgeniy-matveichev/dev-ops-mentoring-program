using Module1.TypesAndClasses.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module1.TypesAndClasses.Factories
{
    public class InputCommandsPool
    {
        private readonly IEnumerable<IInputCommand> _commands;

        public InputCommandsPool(IEnumerable<IInputCommand> commands)
        {
            _commands = commands ?? throw new ArgumentNullException();
        }

        public IInputCommand Take(string commandName)
        {
            return commandName switch
            {
                "list" => _commands.Single(c => c.Name == nameof(ListCommand)),
                "import" => _commands.Single(c => c.Name == nameof(ImportCommand)),
                "export" => _commands.Single(c => c.Name == nameof(ExportCommand)),
                "help" => _commands.Single(c => c.Name == nameof(HelpCommand)),
                _ => throw new NotSupportedException($"Unknown command name: '{commandName}'"),
            };
        }
    }
}
