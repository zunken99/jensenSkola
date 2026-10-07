namespace WestcoastEd;

public class Repository<T>  //använder repository för att minska repetitiv kod, även kontrollera hur datan i klasserna interageras med
{
    private readonly List<T> _items;
    private readonly string _fileName;

    public IReadOnlyList<T> Items => _items;

    public Repository(string fileName)
    {
        _fileName = fileName;
        _items = JsonStorage.Load<T>(fileName);
    }

    public void Add(T item)
    {
        _items.Add(item);
        Save();
    }

    public void Save() => JsonStorage.Save(_fileName, _items);

    public void PrintAll(string heading)
    {
        Console.WriteLine($"\n--- {heading} ---");
        if (_items.Count == 0) Console.WriteLine("(inga)");
        foreach (var item in _items) Console.WriteLine(item);
    }
}