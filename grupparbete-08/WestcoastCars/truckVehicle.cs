using System.Text.Encodings.Web;
using System.Text.Json;

namespace WestcoastCars;

public class Truck(
    string make, string model, int year, string color, string mileage, string fuelType,
    string registrationNumber, int loadCapacity, bool hasTailLift = false,
    string engineSize="", string transmissionType="", string numberOfDoors="") 
    : Car(make, model, year, color, mileage, fuelType, registrationNumber, engineSize, transmissionType, numberOfDoors)
{
    public int LoadCapacity { get; set; } = loadCapacity;
    public bool HasTailLift { get; set; } = hasTailLift;

    public override void DisplayVehicleInfo()
    {
        base.DisplayVehicleInfo();
        Console.WriteLine($"Load Capacity: {LoadCapacity} kg");
        Console.WriteLine($"Has Tail Lift: {HasTailLift}");
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