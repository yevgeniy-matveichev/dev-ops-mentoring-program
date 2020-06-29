using Module1.TypesAndClasses.Commands;
using Module1.TypesAndClasses.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module1.TypesAndClasses.Services
{
    public class UserInputProcessingService
    {
        public static readonly Dictionary<string, string> ShapeCommandsMapping = new Dictionary<string, string>
        {
            { "c", "Circle" },
            { "e", "Ellipse" },
            { "r", "Rectangle" },
            { "t", "EquilateralTriangle" }
        };

        static readonly List<string> ParametersList = new List<string>
        {
            "help", "list", "import", "export", "exit"
        }.OrderBy(x => x).ToList();

        // ??? 
        private readonly InputCommandsPool _inputCommandsPool;

        // ???
        public UserInputProcessingService(InputCommandsPool inputCommandsPool)
        {
            _inputCommandsPool = inputCommandsPool;
        }

        public void Run()
        {
            //List<string> supportedShapes = args.ToList();

            //if (!supportedShapes.Any())
            //{
            //    supportedShapes.AddRange(ShapeCommandsMapping.Keys);
            //}

            List<string> supportedShapes = new List<string>();
            supportedShapes.AddRange(ShapeCommandsMapping.Keys);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hello! This is Shapes program. Supported commands: {string.Join(", ", ParametersList)}. {Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.White;

            string userInput;

            while (!(userInput = Console.ReadLine()).Equals("exit"))
            {
                string[] parameters = userInput.Trim().Split(' ');

                if (!ParametersList.Contains(parameters[0]))
                {
                    Console.WriteLine($"The Shapes program does not support command '{userInput}'.");
                }

                try
                {
                    string commandName = parameters[0].ToLower().Trim();

                    // todo: make it work :)
                    /*
                    var commandsFactory = serviceProvider.GetService<InputCommandsPool>();
                    IInputCommand command = commandsFactory.Take(commandName);
                    */

                    string validationMessage = command.Validate(parameters);

                    if (!string.IsNullOrEmpty(validationMessage))
                    {
                        Console.WriteLine(validationMessage);
                        continue;
                    }

                    Console.WriteLine(command.Execute(parameters) ?? $"Command '{commandName}' executed.");
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
