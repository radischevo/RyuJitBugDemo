# RyuJIT Bug Demo

This project demonstrates the bug in RyuJIT.

The following code is expected to throw a `NullReferenceException`, but when running on Windows x64, the application crashes instead with `c0000005` (Access Violation) in either `clr.dll` or `coreclr.dll`.
```
public static class Program
{
    public static void Main(string[] args)
    {
        Container container = null;
        Console.WriteLine($"{container.Item}.");
    }
}

public struct Option
{
    private object _foo;
    private int _bar;
}

public class Container
{
    public Container(Option item)
    {
        Item = item;
    }

    public Option Item { get; }
}
```

The bug affects both .NET 4.7.2 and .NET Core 2.1 apps running on Windows. The same code running under MacOS does not have the issue. Debug and AnyCPU builds run OK too.

.NET Core 2.2 and 3.0 apps seem not be affected.

Please note, that the issue is tighly related to the fact, that `Option` is a value type that has at least two fields: one of a reference type, and the other one of arbitrary type. If the structure contains one field, or both of the fields are value types, the problem does not occur.
