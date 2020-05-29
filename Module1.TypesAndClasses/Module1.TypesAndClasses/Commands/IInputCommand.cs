using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Commands
{
    interface IInputCommand
    {
        string Execute(string instruction);

        string Validate();
    }
}
