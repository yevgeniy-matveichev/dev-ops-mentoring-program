using Module1.TypesAndClasses.Commands;
using System;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Commands
{
    public class HelpCommandTests
    {
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

        // todo
        [Fact]
        public void HelpCommand_Execute_OneParam()
        {
            HelpCommand command = new HelpCommand(new string[] { "help" });
            //Assert.Equal();
        }

        [Theory]
        [InlineData("help", "help\t\tDescribes Shapes program commands.\r\n\t\tExample: help list")]
        [InlineData("list", "list\t\tShows the example of the shape.\r\n\t\tExample: list -json-example c")]
        [InlineData("import", "import\t\tImports the shape from the path.\r\n\t\tExample: import -path D:\\temp\\file.json -shapeType c")]
        [InlineData("export", "export\t\tExports the shape to JSON file, saves the file to specified path.\r\n\t\tExample: export -path D:\\temp\\circle.json -shapeType c")]
        [InlineData("exit", "exit\t\tExits the Shapes program.")]
        public void HelpCommand_Execute(string instruction, string expectedMsg)
        {
            HelpCommand command = new HelpCommand(new string[] { "help", instruction });
            Assert.Equal(expectedMsg, command.Execute());
        }

        [Fact]
        public void HelpCommand_Execute_Throws()
        {
            HelpCommand command = new HelpCommand(new string[] { "help", "me" });
            Assert.Throws<NotSupportedException>(() => command.Execute());
        }
    }
}
