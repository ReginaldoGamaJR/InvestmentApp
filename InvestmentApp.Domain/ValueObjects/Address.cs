namespace InvestmentApp.Domain.ValueObjects;

public class Address
{
    public string ZipCode { get; private set; }
    public string Street { get; private set; }
    public string? Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string? AdditionalInfo { get; private set; }

    public Address(string zipCode, string street, string? number,
                   string neighborhood, string city, string state,
                   string country, string? additionalInfo)
    {
        ZipCode = zipCode;
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        AdditionalInfo = additionalInfo;
    }
}