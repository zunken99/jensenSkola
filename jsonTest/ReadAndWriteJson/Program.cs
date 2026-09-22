using System.Text.Encodings.Web;
using System.Text.Json;

namespace ReadAndWriteJson;

class Person
{
    public string FirstName { get; set; }= "";  
    public string LastName { get; set; }= "";
}



class Program
{
    static void Main()
    {
        string path = string .Concat(Environment.CurrentDirectory, "/data/person.json");

        //Console.WriteLine(path);

        Person person = new()
        {
            FirstName = "John",
            LastName = "Doe"
        };

        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping

        };

        var json = JsonSerializer.Serialize(person, options);

        File.WriteAllText(path, json);

        var jsonFromFile = File.ReadAllText(path);
        //Console.WriteLine(jsonFromFile);

        options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
        Person? person1 = JsonSerializer.Deserialize<Person>(jsonFromFile, options)!;
        Console.WriteLine(person1.FirstName);
    }
}
