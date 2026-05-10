using APBD_PJATK_Cw3_s29764.DTOs.Reservation;
using APBD_PJATK_Cw3_s29764.Exceptions;
using APBD_PJATK_Cw3_s29764.Services.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace APBD_PJATK_Cw3_s29764.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController(IReservationService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] DateTime? date,
        [FromQuery] string? status,
        [FromQuery] int? roomId)
    {
        var reservations = service.GetAll();
        
        if (date.HasValue)
        {
            var filterDate = date.Value.Date;
            reservations = reservations.Where(r =>
                r.startTime.Date <= filterDate && 
                r.endTime.Date >= filterDate);
        }
        
        if (!string.IsNullOrWhiteSpace(status))
        {
            reservations = reservations.Where(r =>
                r.status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }
        
        if (roomId.HasValue)
        {
            reservations = reservations.Where(r => r.roomId == roomId.Value);
        }

        return Ok(reservations.ToList());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        try
        {
            return Ok(service.GetById(id));
        }
        catch (ObjectNotInRepositoryException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateReservationDTO reservation)
    {
        var tmpReservation = service.Add(reservation);
        
        return CreatedAtAction(
            nameof(GetById), 
            new { id = tmpReservation.Id },
            tmpReservation
        );
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(
        [FromRoute] int id, 
        [FromBody] UpdateReservationDTO reservation
    )
    {
        try
        {
            return Ok(service.Update(id, reservation));
        }
        catch (ObjectNotInRepositoryException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            service.Remove(id);
            return NoContent();
        }
        catch (ObjectNotInRepositoryException e)
        {
            return NotFound(e.Message);
        }
    }
}