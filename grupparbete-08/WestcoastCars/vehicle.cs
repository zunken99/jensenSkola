namespace WestcoastCars;

public abstract class Vehicle(string make, string model, int year, string color, string mileage, string fuelType, string registrationNumber)
{
    public string Make { get; set; } = make;
    public string Model { get; set; } = model;
    public int Year { get; set; } = year;
    public string Color { get; set; } = color;
    public string Mileage { get; set; } = mileage;
    public string FuelType { get; set; } = fuelType;
    public string RegistrationNumber { get; set; } = registrationNumber;

    public abstract void DisplayVehicleInfo();
    
}
    
