using System.Text.Json;

namespace WestcoastCars;
class Program
{
    static void Main()
    {
        string jsonFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/data/vehicles.json";

        Car volvo = new Car("Volvo", "V90", 2020, "Black", "15000", "Diesel", "ABC123", "2.0L", "Automatic", "5");
        Bike harley = new Bike("Harley-Davidson", "Street 750", 2019, "Red", "5000", "Petrol", "XYZ789", "Cruiser");
        Truck scania = new Truck("Scania", "R500", 2021, "White", "20000", "Diesel", "TRK456", 20000, true, "12.7L", "Manual", "2");

        displayVehicleInfo(volvo, harley, scania);
    }

    private static void displayVehicleInfo(Car volvo, Bike harley, Truck scania)
    {
        Console.WriteLine("Car Information:");
        volvo.DisplayVehicleInfo();
        Console.WriteLine();

        Console.WriteLine("Bike Information:");
        harley.DisplayVehicleInfo();
        Console.WriteLine();

        Console.WriteLine("Truck Information:");
        scania.DisplayVehicleInfo();
    }

    private static void WriteVehicleInfoJSON(Vehicle vehicle, string jsonFilePath)
    {
        string json = System.Text.Json.JsonSerializer.Serialize(vehicle);
        File.AppendAllText(jsonFilePath, "\n" + json);
    }
}
