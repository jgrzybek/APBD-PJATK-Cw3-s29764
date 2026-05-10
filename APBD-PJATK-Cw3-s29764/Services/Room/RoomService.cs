using APBD_PJATK_Cw3_s29764.DTOs.Room;
using APBD_PJATK_Cw3_s29764.Exceptions;
using APBD_PJATK_Cw3_s29764.mappers;
using APBD_PJATK_Cw3_s29764.Repositories;

namespace APBD_PJATK_Cw3_s29764.Services.Room;

public class RoomService(IRoomRepository roomRepository, IReservationRepository reservationRepository) : IRoomService
{
    public IEnumerable<RoomDTO> GetAll()
    {
        return roomRepository.GetAll()
            .Select(room => room.ToDto());
    }

    public RoomDTO GetById(int id)
    {
        var tmpRoom = roomRepository.GetById(id);
        return tmpRoom is not null
            ? tmpRoom.ToDto()
            : throw new ObjectNotInRepositoryException(id);
    }

    public IEnumerable<RoomDTO> GetByBuildingCode(string buildingCode)
    {
        var tmpRoom = roomRepository.GetByBuildingCode(buildingCode);

        return tmpRoom.Select(room => room.ToDto());
    }

    public RoomDTO Add(CreateRoomDTO room)
    {
        var roomToAdd = room.ToDomain();
        roomRepository.Add(roomToAdd);
        
        return roomToAdd.ToDto();
    }

    public RoomDTO Update(int id, UpdateRoomDTO room)
    {
        var tmpRoom = room.ToDomain();
        tmpRoom.Id = id;

        return !roomRepository.Update(tmpRoom) 
            ? throw new ObjectNotInRepositoryException(id) 
            : tmpRoom.ToDto();
    }

    public void Remove(int id)
    {
        var room = roomRepository.GetById(id);
        if (room == null)
            throw new ObjectNotInRepositoryException(id);
        
        var futureReservations = reservationRepository.GetAll()
            .Any(r => r.roomId == id && r.startTime > DateTime.Now);

        if (futureReservations)
        {
            throw new FutureReservationException();
        }

        roomRepository.Remove(room);
    }
}