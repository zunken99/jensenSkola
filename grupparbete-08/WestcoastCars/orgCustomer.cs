using System.Text.Encodings.Web;
using System.Text.Json;

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

    public override void WriteCustomerInfoJSON(string jsonFilePath)
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