using Microsoft.Extensions.DependencyInjection;
using Module1.TypesAndClasses.Commands;
using Module1.TypesAndClasses.Factories;
using Module1.TypesAndClasses.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module1.TypesAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<InputCommandsPool>()
                .AddSingleton<IInputCommand, ListCommand>()
                .AddSingleton<IInputCommand, HelpCommand>()
                .AddSingleton<IInputCommand, ImportCommand>()
                .AddSingleton<IInputCommand, ExportCommand>()
                .AddSingleton<UserInputProcessingService>()
                .BuildServiceProvider();

            var userInputProvider = serviceProvider.GetService<UserInputProcessingService>();
            userInputProvider.Run();
        }
    }
}