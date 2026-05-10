namespace APBD_PJATK_Cw3_s29764.DTOs.Room;

public class UpdateRoomDTO
{
    int Id { get; set; }
    string Name { get; set; } = string.Empty;
    string buildingCode { get; set; } = string.Empty;
    int floor  { get; set; }
    int capacity { get; set; }
    bool hasProjector { get; set; }
    bool isActive { get; set; }
}