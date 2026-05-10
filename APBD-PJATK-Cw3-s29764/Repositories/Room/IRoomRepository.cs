using APBD_PJATK_Cw3_s29764.Models;

namespace APBD_PJATK_Cw3_s29764.Repositories;

public interface IRoomRepository
{
    IEnumerable<Room> GetAll(); 
    Room? GetById(int id);
    IEnumerable<Room> GetByBuildingCode(string buildingCode);
    void Add(Room room);
    bool Update(Room room);
    void Remove(Room room);
    bool Exists(int id);
}