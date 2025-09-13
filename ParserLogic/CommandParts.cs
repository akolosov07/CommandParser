namespace ParserLogic
{
    public ref struct CommandParts
    {
        public ReadOnlySpan<char> Command;
        public ReadOnlySpan<char> Key;
        public ReadOnlySpan<char> Value;
    }
}
