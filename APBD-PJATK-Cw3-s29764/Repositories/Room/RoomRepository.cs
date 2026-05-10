using APBD_PJATK_Cw3_s29764.Models;

namespace APBD_PJATK_Cw3_s29764.Repositories;

public class RoomRepository : IRoomRepository
{
    private static int _nextId = 1;
    private readonly List<Room> _rooms = [];
    
    public IEnumerable<Room> GetAll()
    {
        return _rooms;
    }

    public IEnumerable<Room> GetByBuildingCode(string buildingCode)
    {
        return _rooms.Where(x => x.buildingCode == buildingCode);
    }

    public Room? GetById(int id)
    {
        return _rooms.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Room room)
    {
        room.Id = _nextId++;
        _rooms.Add(room);
    }

    public bool Update(Room room)
    {
        var existing = GetById(room.Id);
        if (existing is null) return false;
        
        existing.Name = room.Name;
        existing.buildingCode = room.buildingCode;
        existing.floor = room.floor;
        existing.capacity = room.capacity;
        existing.hasProjector = room.hasProjector;
        existing.isActive = room.isActive;
        return true;
    }

    public void Remove(Room room)
    {
        _rooms.Remove(room);
    }

    public bool Exists(int id)
    {
        return _rooms.Any(x => x.Id == id);
    }
}