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
}