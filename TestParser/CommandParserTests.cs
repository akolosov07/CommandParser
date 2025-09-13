using ParserLogic;

namespace TestParser
{
    public class CommandParserTests
    {
        [Fact]
        public void Parse_SetCommand_WithThreeArguments()
        {
            var input = "SET user:1 data";
            var commandParts = CommandParser.Parse(input.AsSpan());
            Assert.Equal("SET", commandParts.Command.ToString());
            Assert.Equal("user:1", commandParts.Key.ToString());
            Assert.Equal("data", commandParts.Value.ToString());
        }

        [Fact]
        public void Parse_GetCommand_WithTwoArguments()
        {
            var input = "GET user:1";
            var commandParts = CommandParser.Parse(input.AsSpan());
            Assert.Equal("GET", commandParts.Command.ToString());
            Assert.Equal("user:1", commandParts.Key.ToString());
            Assert.True(commandParts.Value.IsEmpty);
        }

        [Fact]
        public void Parse_InvalidCommand_NoKey()
        {
            var input = "SET   ";
            var commandParts = CommandParser.Parse(input.AsSpan());
            Assert.True(commandParts.Command.IsEmpty);
            Assert.True(commandParts.Key.IsEmpty);
            Assert.True(commandParts.Value.IsEmpty);
        }

        [Fact]
        public void Parse_CommandWithExtraSpaces()
        {
            var input = "  SET      user:1    data   ";
            var commandParts = CommandParser.Parse(input.AsSpan());
            Assert.Equal("SET", commandParts.Command.ToString());
            Assert.Equal("user:1", commandParts.Key.ToString());
            Assert.Equal("data", commandParts.Value.ToString());
        }
    }
}
