namespace Models;
public class DeliveryAddress
{
    public int DeliveryAddressId {get; set;}
    public string Street {get; set;}
    public int HouseNumber {get; set;}
    public string? HouseNumberExtension {get; set;}
    public string City {get; set;}
    public string Postcode {get; set;}

}