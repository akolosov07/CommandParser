# CommandParser

������� ������ ������ �� C# � ������������ �������� ������ � ������.

## ��������

������ ���������:

- ������ ������, ����������� ���� �� `Command`, `Key` � `Value`.
- ������� in-memory ��������� ����-�������� (`SimpleStore`).
- ����� ������ ��� �������� ������ ������� ������.

������������ `ReadOnlySpan<char>` ��� ����������� ������ � ������� ������� ��� ������� ��������� ������.

## �������������

### ������� ������

```csharp
using ParserLogic;

var input = "SET user:1 data";
var parts = CommandParser.Parse(input.AsSpan());

Console.WriteLine(parts.Command.ToString()); // "SET"
Console.WriteLine(parts.Key.ToString());     // "user:1"
Console.WriteLine(parts.Value.ToString());   // "data"

