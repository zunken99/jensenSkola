using System.Text.Encodings.Web;
using System.Text.Json;

namespace WestcoastCars;
class Program
{
    static void Main()
    {
        string jsonFilePath = string.Concat(Environment.CurrentDirectory, "/data/vehicle.json");
        string customerJsonFilePath = string.Concat(Environment.CurrentDirectory, "/data/customer.json");
        

        Car volvo = new("Volvo", "V90", 2020, "Black", "15000", "Diesel", "ABC123", "2.0L", "Automatic", "5");
        Bike harley = new("Harley-Davidson", "Street 750", 2019, "Red", "5000", "Petrol", "XYZ789", "Cruiser");
        Truck scania = new("Scania", "R500", 2021, "White", "20000", "Diesel", "TRK456", 20000, true, "12.7L", "Manual", "2");

        PrivateCustomer isak = new("isak", "svensson", "19900101-1234", 123456789, "Malmögatan Malmö", "Malmögatan Ystad", "0701234567");
        OrganizationCustomer bosseBil = new("Bosse bildoktor", "556677-8899", 987654321, "Storgatan Malmö", "Storgatan Ystad", "0709876543");

        foreach (var vehicle in new Vehicle[] { volvo, harley, scania })
        {
            WriteVehicleInfoJSON(vehicle, jsonFilePath);
        }

        foreach (var customer in new Customer[] { isak, bosseBil })
        {
            customer.WriteCustomerInfoJSON(customerJsonFilePath);
        }
    }

    private static void DisplayVehicleInfo(Car volvo, Bike harley, Truck scania)
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
        vehicle.WriteVehicleInfoJSON(jsonFilePath);
    }
    
}
