using Microsoft.Extensions.DependencyInjection;
using Module1.TypesAndClasses.Commands;
using Module1.TypesAndClasses.Factories;
using Module1.TypesAndClasses.Services;
using log4net;
using log4net.Config;
using System.Reflection;
using System.IO;
using System;

namespace Module1.TypesAndClasses
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            var fi = new FileInfo("log4net.config");
            XmlConfigurator.Configure(logRepository, fi);

            Console.WriteLine("Testing some logs...");

            // Log some things
            log.Info("Hello logging world!");
            log.Error("Error!");
            log.Warn("Warn!");

            var serviceProvider = new ServiceCollection()
                .AddSingleton<InputCommandsPool>()
                .AddSingleton<IInputCommand, ListCommand>()
                .AddSingleton<IInputCommand, HelpCommand>()
                .AddSingleton<IInputCommand, ImportCommand>()
                .AddSingleton<IInputCommand, ExportCommand>()
                .AddSingleton<UserInputProcessingService>()
                .AddSingleton(log)
                .BuildServiceProvider();

            var userInputProvider = serviceProvider.GetService<UserInputProcessingService>();
            userInputProvider.Run();
        }
    }
}