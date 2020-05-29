using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Commands
{
    class ImportCommand : IInputCommand
    {
        private readonly string[] _inputParameters;

        public ImportCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));
        }

        public string Execute()
        {
            return "Method is not implemented.";
        }

        public string Validate()
        {
            // validates the path (that file is json and exists)
            // File.Exists("<path>");
            throw new NotImplementedException();
        }
    }
}
