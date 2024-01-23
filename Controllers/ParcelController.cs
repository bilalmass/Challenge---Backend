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
    public async Task<ActionResult<Parcel>> GetParcel(string trackingNumber)
    {
        var parcel = await _context.Parcels.FindAsync(trackingNumber);
        
        if (parcel == null) return NotFound("Het pakket is niet gevonden");

        return parcel;
    }

    [HttpPost]
    public async Task<ActionResult<Parcel>> RegisterParcel([FromBody] Parcel parcel)
    {
        parcel.TrackingNumber = Guid.NewGuid().ToString();
        // opslaan van pakket in database
        await _context.Parcels.AddAsync(parcel);
        // nieuw object om alleen de tracking nummer terug te sturen
        var result = new { TrackingNumber = parcel.TrackingNumber};

        return CreatedAtAction(nameof(GetParcel), new { id = parcel.TrackingNumber}, result);
    }

}