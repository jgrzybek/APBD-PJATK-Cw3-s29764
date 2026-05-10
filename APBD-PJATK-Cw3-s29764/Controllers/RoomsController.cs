using APBD_PJATK_Cw3_s29764.DTOs.Room;
using APBD_PJATK_Cw3_s29764.Exceptions;
using APBD_PJATK_Cw3_s29764.Services.Room;
using Microsoft.AspNetCore.Mvc;

namespace APBD_PJATK_Cw3_s29764.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController(IRoomService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(service.GetAll());
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
    public IActionResult Add([FromBody] CreateRoomDTO room)
    {
        var tmpRoom = service.Add(room);
        
        return CreatedAtAction(
            nameof(GetById), 
            new { id = tmpRoom.Id },
            tmpRoom
        );
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(
        [FromRoute] int id, 
        [FromBody] UpdateRoomDTO room
    )
    {
        try
        {
            return Ok(service.Update(id, room));
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