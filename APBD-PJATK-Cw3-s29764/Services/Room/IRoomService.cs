using APBD_PJATK_Cw3_s29764.DTOs.Room;

namespace APBD_PJATK_Cw3_s29764.Services.Room;

public interface IRoomService
{
    IEnumerable<RoomDTO> GetAll();
    RoomDTO GetById(int id);
    IEnumerable<RoomDTO> GetByBuildingCode(string buildingCode);
    RoomDTO Add(CreateRoomDTO room);
    RoomDTO Update(int id, UpdateRoomDTO room);
    void Remove(int id);
}