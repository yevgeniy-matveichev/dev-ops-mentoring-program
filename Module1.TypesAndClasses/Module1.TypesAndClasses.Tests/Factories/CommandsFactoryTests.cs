using Module1.TypesAndClasses.Commands;
using Module1.TypesAndClasses.Factories;
using System;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Factories
{
    public class CommandsFactoryTests
    {
        private readonly CommandsFactory _factory = new CommandsFactory(new string[] { "param1", "param2", "param3", "param4" });

        [Theory]
        [InlineData("list", typeof(ListCommand))]
        [InlineData("help", typeof(HelpCommand))]
        [InlineData("export", typeof(ExportCommand))]
        [InlineData("import", typeof(ImportCommand))]
        public void TestCommandsFactory_Create(string param, Type t)
        {
            IInputCommand command = _factory.Create(param);
            Assert.NotNull(command);
            Assert.IsType(t, command);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("wrongCommand")]
        public void TestCommandsFactory_Fail(string param)
        {
            Assert.Throws<NotSupportedException>(() => _factory.Create(param)); 
        }
    }
}
