namespace Models;
public class Parcel
{
    public int ParcelId {get; set;}
    public string Name {get; set;}
    public DateTime DeliveryDate {get; set;}
    public DeliveryAddress deliveryAddress {get; set;}
    public int Weight {get; set;}
    public Dimension Dimension {get; set;}
    public String TrackingNumber {get; set;}
    public String Status {get; set;}
    
}