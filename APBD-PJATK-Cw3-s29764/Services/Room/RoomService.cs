using APBD_PJATK_Cw3_s29764.DTOs.Room;
using APBD_PJATK_Cw3_s29764.Exceptions;
using APBD_PJATK_Cw3_s29764.mappers;
using APBD_PJATK_Cw3_s29764.Repositories;

namespace APBD_PJATK_Cw3_s29764.Services.Room;

public class RoomService(IRoomRepository repository) : IRoomService
{
    public IEnumerable<RoomDTO> GetAll()
    {
        return repository.GetAll()
            .Select(room => room.ToDto());
    }

    public RoomDTO GetById(int id)
    {
        var tmpRoom = repository.GetById(id);
        return tmpRoom is not null
            ? tmpRoom.ToDto()
            : throw new ObjectNotInRepositoryException(id);
    }

    public IEnumerable<RoomDTO> GetByBuildingCode(string buildingCode)
    {
        var tmpRoom = repository.GetByBuildingCode(buildingCode);

        return tmpRoom.Select(room => room.ToDto());
    }

    public RoomDTO Add(CreateRoomDTO room)
    {
        var roomToAdd = room.ToDomain();
        repository.Add(roomToAdd);
        
        return roomToAdd.ToDto();
    }

    public RoomDTO Update(int id, UpdateRoomDTO room)
    {
        var tmpRoom = room.ToDomain();
        tmpRoom.Id = id;

        return !repository.Update(tmpRoom) 
            ? throw new ObjectNotInRepositoryException(id) 
            : tmpRoom.ToDto();
    }

    public void Remove(int id)
    {
        var tmpRoom = repository.GetById(id);
        
        if (tmpRoom is null)
        {
            throw new ObjectNotInRepositoryException(id);
        }
        
        repository.Remove(tmpRoom);
    }
}