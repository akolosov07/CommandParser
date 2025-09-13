# CommandParser

Простой парсер команд на C# с возможностью хранения данных в памяти.

## Описание

Проект реализует:

- Парсер команд, разделяющих ввод на `Command`, `Key` и `Value`.
- Простое in-memory хранилище ключ-значение (`SimpleStore`).
- Набор тестов для проверки работы парсера команд.

Используется `ReadOnlySpan<char>` для эффективной работы с входной строкой без лишнего выделения памяти.

## Использование

### Парсинг команд

```csharp
using ParserLogic;

var input = "SET user:1 data";
var parts = CommandParser.Parse(input.AsSpan());

Console.WriteLine(parts.Command.ToString()); // "SET"
Console.WriteLine(parts.Key.ToString());     // "user:1"
Console.WriteLine(parts.Value.ToString());   // "data"

