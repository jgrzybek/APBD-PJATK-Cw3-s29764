using APBD_PJATK_Cw3_s29764.DTOs.Room;
using APBD_PJATK_Cw3_s29764.Models;

namespace APBD_PJATK_Cw3_s29764.mappers;

public static class RoomMappingExtensions
{
    public static Room ToDomain(this RoomDTO dto)
    {
        return new Room
        {
            Id = dto.Id,
            Name = dto.Name,
            buildingCode =  dto.buildingCode,
            floor = dto.floor,
            capacity = dto.capacity,
            hasProjector = dto.hasProjector,
            isActive = dto.isActive
        };
    }

    public static Room ToDomain(this CreateRoomDTO dto)
    {
        return new Room
        {
            Name = dto.Name,
            buildingCode =  dto.buildingCode,
            floor = dto.floor,
            capacity = dto.capacity,
            hasProjector = dto.hasProjector,
            isActive = dto.isActive
        };
    }

    public static Room ToDomain(this UpdateRoomDTO dto)
    {
        return new Room
        {
            Name = dto.Name,
            buildingCode =  dto.buildingCode,
            floor = dto.floor,
            capacity = dto.capacity,
            hasProjector = dto.hasProjector,
            isActive = dto.isActive
        };
    }
    
    public static RoomDTO ToDto(this Room room)
    {
        return new RoomDTO
        {
            Id = room.Id,
            Name = room.Name,
            buildingCode =  room.buildingCode,
            floor = room.floor,
            capacity = room.capacity,
            hasProjector = room.hasProjector,
            isActive = room.isActive
        };
    }
}