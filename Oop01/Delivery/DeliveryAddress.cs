namespace Oop04.Delivery;

public struct DeliveryAddress
{
    public string City { get; set; }
    public string Street { get; set; }
    public int BuildingNumber { get; set; }

    public DeliveryAddress(string city, string street, int buildingNumber)
    {
        City = city;
        Street = street;
        BuildingNumber = buildingNumber;
    }
    public string GetFullAddress()
    {
        return $"{City}, {Street}, Building {BuildingNumber}";
    }
}
