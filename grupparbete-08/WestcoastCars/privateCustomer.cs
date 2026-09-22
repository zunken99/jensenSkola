namespace WestcoastCars;

public class PrivateCustomer : Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalNumber { get; set; }

    public PrivateCustomer(string firstName, string lastName, string personalNumber, int email, string deliveryAddress, string invoiceAddress, string phoneNumber)
        : base(email, deliveryAddress, invoiceAddress, phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PersonalNumber = personalNumber;
    }
}