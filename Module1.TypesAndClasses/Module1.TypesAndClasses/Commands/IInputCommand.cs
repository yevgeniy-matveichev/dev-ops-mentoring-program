using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Commands
{
    public interface IInputCommand
    {
        string Name { get; }

        string Execute(string[] inputParameters);

        string Validate(string[] inputParameters);
    }
}
