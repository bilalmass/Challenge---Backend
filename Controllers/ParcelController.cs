using Microsoft.AspNetCore.Mvc;
using Models;
using Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace Controllers;

[Route("Parcel")]
[ApiController]
public class ParcelController : ControllerBase
{
    private readonly DatabaseContext _context;

    public ParcelController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet("{trackingNumber}")]
    public async Task<ActionResult<string>> GetParcel(string trackingNumber)
    {
        var parcel = await _context.Parcels.FindAsync(trackingNumber);
        
        if (parcel == null) return NotFound("Het pakket is niet gevonden");

        return parcel.Status;
    }

    [HttpPost]
    public async Task<ActionResult<Parcel>> RegisterParcel([FromBody] ParcelReqData parcelReq)
    {
        var parcel = new Parcel {
            Name = parcelReq.name,
            DeliveryDate = parcelReq.deliveryDate, 
            deliveryAddress = new DeliveryAddress {
                Address = parcelReq.address,
                City = parcelReq.city,
                Postcode = parcelReq.address,
                Country = parcelReq.country
            },
            Weight = parcelReq.weight,
            Dimension = new Dimension {
                Height = parcelReq.height,
                Length = parcelReq.length,
                Width = parcelReq.width
            },
            Status = "Aangemeld"
            
        };
        parcel.TrackingNumber = Guid.NewGuid().ToString();

        await _context.Parcels.AddAsync(parcel);
        await _context.SaveChangesAsync();
        // nieuw object om alleen de tracking nummer terug te sturen
        var result = new { TrackingNumber = parcel.TrackingNumber};

        return Ok(new { trackingNumber = parcel.TrackingNumber }); 
}

}

public class ParcelReqData
{
    public string name {get; set;}
    public DateTime deliveryDate {get; set;}
    public string address {get; set;}
    public string postcode {get; set;}
    public string city {get; set;}
    public string country {get; set;}
    public int weight {get; set;}
    public int length {get; set;}
    public int height {get; set;}
    public int width {get; set;}
}