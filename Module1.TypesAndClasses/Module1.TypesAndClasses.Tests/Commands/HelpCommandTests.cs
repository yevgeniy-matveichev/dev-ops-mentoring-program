using Module1.TypesAndClasses.Commands;
using System;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Commands
{
    public class HelpCommandTests
    {
        #region Validate()

        [Theory]
        [InlineData("help", "help", "help")]
        public void HelpCommand_Validate_TooMuchParams(params string[] param)
        {
            HelpCommand command = new HelpCommand(param);
            string expected = $"Incorrect usage of 'help' command: '{string.Join(" ", param)}'. {Environment.NewLine}" +
                    "Example: help list.";
            Assert.Equal(expected, command.Validate());
        }

        [Theory]
        [InlineData("help", "me")]
        public void HelpCommand_Validate_SecondParam(params string[] param)
        {
            HelpCommand command = new HelpCommand(param);
            string expected = $"Incorrect usage of 'help' command: '{param[1]}' is not recognized as an option. {Environment.NewLine}" +
                        "Example: help list.";
            Assert.Equal(expected, command.Validate());
        }

        #endregion

        // ?????????????
        [Fact]
        public void HelpCommand_NotNull()
        {
            HelpCommand command = new HelpCommand(new string[] { "param1", "param2" });
            Assert.NotNull(command);
        }

        //[Theory]
        //[InlineData("help")]
        //[InlineData("list")]
        //[InlineData("import")]
        //[InlineData("export")]
        //[InlineData("exit")]
        //public void HelpCommand_Execute(string instruction)
        //{
        //    HelpCommand command = new HelpCommand(new string[] { "help", instruction });

        //}

        #region Execute()

        // todo
        [Fact]
        public void HelpCommand_Execute_OneParam()
        {
            HelpCommand command = new HelpCommand(new string[] { "help" });
            //Assert.Equal();
        }

        [Fact]
        public void HelpCommand_Execute_Help()
        {
            HelpCommand command = new HelpCommand(new string[] { "help", "help" });
            string expected = $"help\t\tDescribes Shapes program commands.{ Environment.NewLine}\t\tExample: help list";
            Assert.Equal(expected, command.Execute());
        }

        [Fact]
        public void HelpCommand_Execute_List()
        {
            HelpCommand command = new HelpCommand(new string[] { "help", "list" });
            string expected = $"list\t\tShows the example of the shape.{Environment.NewLine}\t\tExample: list -json-example c";
            Assert.Equal(expected, command.Execute());
        }

        [Fact]
        public void HelpCommand_Execute_Import()
        {
            HelpCommand command = new HelpCommand(new string[] { "help", "import" });
            string expected = $"import\t\tImports the shape from the path.{Environment.NewLine}\t\tExample: import -path D:\\temp\\file.json -shapeType c";
            Assert.Equal(expected, command.Execute());
        }

        [Fact]
        public void HelpCommand_Execute_Export()
        {
            HelpCommand command = new HelpCommand(new string[] { "help", "export" });
            string expected = $"export\t\tExports the shape to JSON file, saves the file to specified path.{Environment.NewLine}\t\tExample: export -path D:\\temp\\circle.json -shapeType c";
            Assert.Equal(expected, command.Execute());
        }

        [Fact]
        public void HelpCommand_Execute_Exit()
        {
            HelpCommand command = new HelpCommand(new string[] { "help", "exit" });
            string expected = $"exit\t\tExits the Shapes program.";
            Assert.Equal(expected, command.Execute());
        }

        [Fact]
        public void HelpCommand_Execute_Throws()
        {
            HelpCommand command = new HelpCommand(new string[] { "help", "me" });
            Assert.Throws<NotSupportedException>(() => command.Execute());
        }

        #endregion
    }
}
