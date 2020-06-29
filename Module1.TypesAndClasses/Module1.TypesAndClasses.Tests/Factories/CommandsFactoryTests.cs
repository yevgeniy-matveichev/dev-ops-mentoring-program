using Module1.TypesAndClasses.Commands;
using Module1.TypesAndClasses.Factories;
using System;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Factories
{
    public class CommandsFactoryTests
    {
        private readonly InputCommandsPool _factory = new InputCommandsPool(new string[] { "param1", "param2", "param3", "param4" });

        [Theory]
        [InlineData("list", typeof(ListCommand))]
        [InlineData("help", typeof(HelpCommand))]
        [InlineData("export", typeof(ExportCommand))]
        [InlineData("import", typeof(ImportCommand))]
        public void TestCommandsFactory_Create(string param, Type t)
        {
            IInputCommand command = _factory.Take(param);
            Assert.NotNull(command);
            Assert.IsType(t, command);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("wrongCommand")]
        public void TestCommandsFactory_Throws(string param)
        {
            Assert.Throws<NotSupportedException>(() => _factory.Take(param)); 
        }
    }
}
