namespace WestcoastCars;

public class OrganizationCustomer : Customer
{
    public string OrganizationName { get; set; }
    public string OrganizationNumber { get; set; }

    public OrganizationCustomer(string organizationName, string organizationNumber, int email, string deliveryAddress, string invoiceAddress, string phoneNumber)
        : base(email, deliveryAddress, invoiceAddress, phoneNumber)
    {
        OrganizationName = organizationName;
        OrganizationNumber = organizationNumber;
    }
}