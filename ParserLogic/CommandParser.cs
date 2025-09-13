namespace ParserLogic
{
    public static class CommandParser
    {
        /// <summary>
        /// Парсер 
        /// </summary>
        /// <param name="input">ReadOnlySpan<char></param>
        /// <returns>В данном случае используется возвращаемый объект ref struct CommandParts
        /// т.к. в условиях возвратить кортеж с ReadOnlySpan элементами невозможно
        /// (техническое ограничение компилятора)</returns>
        public static CommandParts Parse(ReadOnlySpan<char> input)
        {
            input = input.Trim();
            if (input.IsEmpty)
                return default;
            int firstSpace = input.IndexOf(' ');
            if (firstSpace == -1)
            {
                // Нет команды
                return default;
            }
            var command = input.Slice(0, firstSpace);
            var rest = input.Slice(firstSpace).Trim();
            if (rest.IsEmpty)
            {
                // нет ключа
                return default;
            }
            int secondSpace = rest.IndexOf(' ');
            if (secondSpace == -1)
            {
                // нет value
                return new CommandParts
                {
                    Command = command,
                    Key = rest,
                    Value = ReadOnlySpan<char>.Empty
                };
            }
            return new CommandParts
            {
                Command = command,
                Key = rest.Slice(0, secondSpace),
                Value = rest.Slice(secondSpace).Trim()
            };
        }
    }
}
