using System.Text.Encodings.Web;
using System.Text.Json;

namespace WestcoastEd;

public static class JsonStorage  //Egen klass för JSON-hantering (rensa upp i program mainfunktionen)
{
    private static readonly string FolderPath =
        string.Concat(Environment.CurrentDirectory, "/data");

    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public static List<T> Load<T>(string fileName)
    {
        var path = Path.Combine(FolderPath, fileName);
        if (!File.Exists(path)) return [];

        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<T>>(json, Options) ?? [];
    }

    public static void Save<T>(string fileName, IReadOnlyList<T> items)
    {
        Directory.CreateDirectory(FolderPath);
        var json = JsonSerializer.Serialize(items, Options);
        File.WriteAllText(Path.Combine(FolderPath, fileName), json);
    }
}