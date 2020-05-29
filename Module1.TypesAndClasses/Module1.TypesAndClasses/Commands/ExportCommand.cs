using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Commands
{
    class ExportCommand : IInputCommand
    {
        private readonly string[] _inputParameters;

        public ExportCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
        }

        public string Execute()
        {
            return "Method is not implemented.";
        }

        public string Validate()
        {
            throw new NotImplementedException();
        }
    }
}
