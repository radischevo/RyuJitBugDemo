# RyuJIT Bug Demo

This project demonstrates the bug in RyuJIT.

The following code is expected to throw a `NullReferenceException`, but when running on Windows x64, the application crashes with `c0000005` (Access Violation) in either `clr.dll` or `coreclr.dll` instead.
```
public struct Option : IEnumerable<Item>
{
    private readonly Item _value;
    private readonly bool _hasValue;

    public Option(Item value)
    {
        _value = value;
        _hasValue = value != null;
    }

    public IEnumerator<Item> GetEnumerator()
    {
        if (_hasValue)
        {
            yield return _value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Item
{
}

public class Container
{
    public Container(Option item)
    {
        Item = item;
    }

    public Option Item { get; }
}

public static class Program
{
    public static void Main(string[] args)
    {
        Container container = null;
        Console.WriteLine($"{container.Item}.");
    }
}
```

The bug affects both .NET 4.7.2 and .NET Core 2.1 apps running on Windows. The same code running under MacOS does not have the issue. 
Debug and AnyCPU builds run OK too.

Please note, that the issue is tighly related to the fact, that `Option` is a value type that implements 
`IEnumerable<T>`, and has at least two fields: one storing the value, and the other one indicating 
whether the value has been assigned. Either putting the `value != null` check inside the enumerator, 
changing the `Container`'s `Item` property type to `IEnumerable<Item>`, or changing `Option` to be a reference type 
would eliminate the issue.
