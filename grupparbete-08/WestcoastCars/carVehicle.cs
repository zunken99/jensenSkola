namespace WestcoastCars;

public class Car : Vehicle
{
    public string EngineSize { get; set; }
    public string TransmissionType { get; set; }
    public string NumberOfDoors { get; set; }

    
    public Car (string make, string model, int year, string color, string mileage, string fuelType, string registrationNumber, string engineSize, string transmissionType, string numberOfDoors)
        : base(make, model, year, color, mileage, fuelType, registrationNumber)
    {
        EngineSize = engineSize;
        TransmissionType = transmissionType;
        NumberOfDoors = numberOfDoors;
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
        Console.WriteLine($"Engine Size: {EngineSize}");
        Console.WriteLine($"Transmission Type: {TransmissionType}");
        Console.WriteLine($"Number of Doors: {NumberOfDoors}");
    }
}