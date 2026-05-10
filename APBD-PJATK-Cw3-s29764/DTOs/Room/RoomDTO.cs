namespace APBD_PJATK_Cw3_s29764.DTOs.Room;

public class RoomDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string buildingCode { get; set; } = string.Empty;
    public int floor  { get; set; }
    public int capacity { get; set; }
    public bool hasProjector { get; set; }
    public bool isActive { get; set; }
}