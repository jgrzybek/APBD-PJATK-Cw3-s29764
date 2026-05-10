using System.ComponentModel.DataAnnotations;

namespace APBD_PJATK_Cw3_s29764.DTOs.Room;

public class CreateRoomDTO
{
    [MinLength(1), MaxLength(50),  Required]
    string Name { get; set; } = string.Empty;
    [MinLength(1), MaxLength(50),  Required]
    string buildingCode { get; set; } = string.Empty;
    int floor  { get; set; }
    [Range(1, int.MaxValue), Required]
    int capacity { get; set; }
    [Required]
    bool hasProjector { get; set; }

    bool isActive { get; set; }
    
}

