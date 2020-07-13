using Mentoring.DataAccess.Interfaces;
using Mentoring.DataAccess.ShapesRepository;
using Microsoft.Extensions.DependencyInjection;
using Module1.TypesAndClasses.Commands;
using Module1.TypesAndClasses.Pools;
using Module1.TypesAndClasses.Services;
using log4net;
using log4net.Config;
using System.Reflection;
using System.IO;

namespace Module1.TypesAndClasses
{
    class Program
    {
        //logs
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            // Load configuration
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            // Log some things
            log.Info("Start logging");

            var serviceProvider = new ServiceCollection()
                .AddSingleton<InputCommandsPool>()
                .AddSingleton<IInputCommand, ListCommand>()
                .AddSingleton<IInputCommand, HelpCommand>()
                .AddSingleton<IInputCommand, ImportCommand>()
                .AddSingleton<IInputCommand, ExportCommand>()
                .AddSingleton<UserInputProcessingService>()

                .AddSingleton<ShapeServicePool>()
                .AddSingleton<IShapesService, CircleService>()
                .AddSingleton<IShapesService, EllipseService>()
                .AddSingleton<IShapesService, RectangleService>()
                .AddSingleton<IShapesService, TriangleService>()
                .AddSingleton(typeof(IShapeRepository<>), typeof(ShapesRepository<>))
                .AddSingleton(log)
                .BuildServiceProvider();
   
        var userInputProvider = serviceProvider.GetService<UserInputProcessingService>();
            userInputProvider.Run();
        }
    }
}