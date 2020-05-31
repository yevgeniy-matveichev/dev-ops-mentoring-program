using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Module1.TypesAndClasses.Commands
{
    class ImportCommand : IInputCommand
    {
        private readonly string[] _inputParameters;
        private readonly string _path;

        public ImportCommand(string[] inputParameters)
        {
            _inputParameters = inputParameters ?? throw new ArgumentNullException(nameof(inputParameters));

            if (_inputParameters.Length < 3) throw new ArgumentNullException(nameof(inputParameters));
            _path = _inputParameters[2];
        }

        public string Execute()
        {
            return "Method is not implemented.";
        }

        public string Validate()
        {
            if (!(_inputParameters.Length == 3))
            {
                return $"Incorrect usage of 'import' command. {Environment.NewLine}" +
                    "Example: import -path D:\\temp\\file.json.";
            }

            if (!(_inputParameters[1] == "-path"))
            {
                return $"Incorrect usage of 'import' command: '{_inputParameters[1]}' is not recognized as an option. {Environment.NewLine}" +
                    "Example: import -path D:\\temp\\file.json.";
            }

            if (!File.Exists(_inputParameters[2]))
            {
                return $"File {_inputParameters[2]} does not exist.";
            }

            if (!_inputParameters[2].EndsWith(".json"))
            {
                return $"Incorrect file extension provided - {_inputParameters[2]}. Must be .json.";
            }

            return string.Empty;
        }
    }
}
