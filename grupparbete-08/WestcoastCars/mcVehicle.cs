using System.Text.Encodings.Web;
using System.Text.Json;

namespace WestcoastCars;

public class Bike : Vehicle
{
    public string Type { get; set; }

    public Bike(string make, string model, int year, string color, string mileage, string fuelType, string registrationNumber, string type)
        : base(make, model, year, color, mileage, fuelType, registrationNumber)
    {
        Type = type;
    }

    public override void DisplayVehicleInfo()
    {
        Console.WriteLine($"Make: {Make}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Mileage: {Mileage}");
        Console.WriteLine($"Fuel Type: {FuelType}");
        Console.WriteLine($"Registration Number: {RegistrationNumber}");
        Console.WriteLine($"Type: {Type}");
    }
    public override void WriteVehicleInfoJSON(string jsonFilePath)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        string json = JsonSerializer.Serialize(this, options);
        File.AppendAllText(jsonFilePath, "\n" + json);
    }
}