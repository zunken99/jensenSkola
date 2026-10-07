using System;

namespace WestcoastEd;

public class Repository<T>
{
    private readonly List<T> _items = new();
    public IReadOnlyList<T> Items => _items;

    public void Add(T item) => _items.Add(item);

    public void PrintAll(string heading)
    {
        Console.WriteLine($"\n--- {heading} ---");
        if (_items.Count == 0) Console.WriteLine("(inga)");
        foreach (var item in _items) Console.WriteLine(item);
    }
}
