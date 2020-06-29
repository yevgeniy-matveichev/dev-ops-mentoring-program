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
        //public static readonly Dictionary<string, string> ShapeCommandsMapping = new Dictionary<string, string>
        //{
        //    { "c", "Circle" },
        //    { "e", "Ellipse" },
        //    { "r", "Rectangle" },
        //    { "t", "EquilateralTriangle" }
        //};

        //static readonly List<string> ParametersList = new List<string>
        //{
        //    "help", "list", "import", "export", "exit"
        //}.OrderBy(x => x).ToList();

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

            //List<string> supportedShapes = args.ToList();

            //if (!supportedShapes.Any())
            //{
            //    supportedShapes.AddRange(ShapeCommandsMapping.Keys);
            //}

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine($"Hello! This is Shapes program. Supported commands: {string.Join(", ", ParametersList)}. {Environment.NewLine}");
            //Console.ForegroundColor = ConsoleColor.White;

            //string userInput;
            
            //while (!(userInput = Console.ReadLine()).Equals("exit"))
            //{
            //    string[] parameters = userInput.Trim().Split(' ');

            //    if(!ParametersList.Contains(parameters[0]))
            //    {
            //        Console.WriteLine($"The Shapes program does not support command '{userInput}'.");
            //    }

            //    try
            //    {
            //        string commandName = parameters[0].ToLower().Trim();

            //        var commandsFactory = serviceProvider.GetService<InputCommandsPool>();
            //        IInputCommand command = commandsFactory.Take(commandName);

            //        string validationMessage = command.Validate(parameters);

            //        if (!string.IsNullOrEmpty(validationMessage))
            //        {
            //            Console.WriteLine(validationMessage);
            //            continue;
            //        }

            //        Console.WriteLine(command.Execute(parameters) ?? $"Command '{commandName}' executed.");
            //    }
            //    catch (NotSupportedException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        continue;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        continue;
            //    }
            //}
        }
    }
}