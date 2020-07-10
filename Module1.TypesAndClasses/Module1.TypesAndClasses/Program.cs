using Mentoring.DataAccess.Interfaces;
using Mentoring.DataAccess.ShapesRepository;
using Mentoring.DataModel.Shapes;
using Microsoft.Extensions.DependencyInjection;
using Module1.TypesAndClasses.Commands;
using Module1.TypesAndClasses.Pools;
using Module1.TypesAndClasses.Services;

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

                .AddSingleton<ShapeServicePool>()
                .AddSingleton<IShapesService, CircleService>()
                .AddSingleton<IShapesService, EllipseService>()
                .AddSingleton<IShapesService, RectangleService>()
                .AddSingleton<IShapesService, TriangleService>()

                .AddSingleton(typeof(IShapeRepository<>), typeof(ShapesRepository<>))

                .BuildServiceProvider();

            var userInputProvider = serviceProvider.GetService<UserInputProcessingService>();
            userInputProvider.Run();
        }
    }
}