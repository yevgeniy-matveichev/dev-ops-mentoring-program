using log4net;
using Module1.TypesAndClasses.Commands;
using Module1.TypesAndClasses.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module1.TypesAndClasses.Pools
{
    public class InputCommandsPool
    {
        private readonly IEnumerable<IInputCommand> _commands;
        private readonly ILog _log;

        public InputCommandsPool(IEnumerable<IInputCommand> commands, ILog log)
        {
            _commands = commands ?? throw new ArgumentNullException();
            _log = log ?? throw new ArgumentNullException();
        }

        public IInputCommand Take(string commandName)
        {
            _log.Info($"running command {commandName}...");
            switch (commandName)
            {
                case "list":
                    return _commands.Single(c => c.Name == nameof(ListCommand));
                case "import":
                    return _commands.Single(c => c.Name == nameof(ImportCommand));
                case "export":
                    return _commands.Single(c => c.Name == nameof(ExportCommand));
                case "help":
                    return _commands.Single(c => c.Name == nameof(HelpCommand));
                default:
                    _log.Error($"Unknown command name: '{commandName}'");
                    throw new CommandNotFoundException($"Unknown command name: '{commandName}'");

            }
        }
    }
}
