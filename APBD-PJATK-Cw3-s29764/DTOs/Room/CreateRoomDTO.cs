using System.ComponentModel.DataAnnotations;

namespace APBD_PJATK_Cw3_s29764.DTOs.Room;

public class CreateRoomDTO
{
    [MinLength(1), MaxLength(50),  Required]
    public string Name { get; set; } = string.Empty;
    [MinLength(1), MaxLength(50),  Required]
    public string buildingCode { get; set; } = string.Empty;
    [Required]
    public int floor  { get; set; }
    [Range(1, int.MaxValue), Required]
    public int capacity { get; set; }
    [Required]
    public bool hasProjector { get; set; }
    [Required]
    public bool isActive { get; set; }
}

