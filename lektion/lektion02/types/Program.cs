namespace types;

public class Vehicle
{
    public string manufacturer = "";
    public string model = "";
    public int modelYear;
    public int mileage;

    public void Accelerate()
    {
        Console.WriteLine("Jag gasar!");
    }

}

public struct Customer
{
    public string firstName = "";
    public string lastName = "";

    public Customer()
    {
    }

    public string GetFullName()
    {
        return $"{firstName} {lastName}";
    }
}

public record Product
{
    public string itemNumber = "";
    public string name = "";
    public int numberInStock;
}
class Program
{
    static void Main(string[] args)
    {
        var volvo = new Vehicle();
        volvo.model = "XC90";
        volvo.modelYear = 2018;
        volvo.manufacturer = "Volvo";
        volvo.mileage = 10000;

        var ford = new Vehicle();
        ford.model = "MACH-E";
        ford.modelYear = 2021;
        ford.manufacturer = "Ford";
        ford.mileage = 5000;

        Console.WriteLine(volvo.model);
        Console.WriteLine(ford.model);

        var isak = new Customer();
        isak.firstName = "Isak";
        isak.lastName = "Svensson";

               
        }
}
