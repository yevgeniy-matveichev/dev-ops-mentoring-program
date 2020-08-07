using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Module1.TypesAndClasses.Commands
{
    public interface IInputCommand
    {
        string Name { get; }

        string Execute(string[] inputParameters);

        Task<string> ExecuteAsync(string[] inputParameters);

        string Validate(string[] inputParameters);
    }
}
