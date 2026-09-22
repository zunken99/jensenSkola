namespace WestcoastCars;


public abstract class Customer(int email, string deliveryAddress, string invoioceAdress, string phoneNumber)
{
    public int Email { get; set; } = email;
    public string DeliveryAddress { get; set; } = deliveryAddress;
    public string InvoiceAddress { get; set; } = invoioceAdress;
    public string PhoneNumber { get; set; } = phoneNumber;

    public abstract void WriteCustomerInfoJSON(string jsonFilePath);
}

