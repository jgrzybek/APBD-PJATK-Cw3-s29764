using System.ComponentModel.DataAnnotations;
using APBD_PJATK_Cw3_s29764.DTOs.Reservation;
using APBD_PJATK_Cw3_s29764.Enums;
using APBD_PJATK_Cw3_s29764.Models;

namespace APBD_PJATK_Cw3_s29764.mappers;

public static class ReservationMappingExtension
{
    public static Reservation ToDomain(this ReservationDTO dto)
    {
        return new Reservation
        {
            Id = dto.Id,
            roomId = dto.roomId,
            organizerName =  dto.organizerName,
            topic =  dto.topic,
            startTime = dto.startTime,
            endTime = dto.endTime,
            status = ConvertStringToStatus(dto.status)
        };
    }

    public static Reservation ToDomain(this CreateReservationDTO dto)
    {
        return new Reservation
        {
            roomId = dto.roomId,
            organizerName =  dto.organizerName,
            topic =  dto.topic,
            startTime = dto.startTime,
            endTime = dto.endTime,
            status = ConvertStringToStatus(dto.status)
        };
    }

    public static Reservation ToDomain(this UpdateReservationDTO dto)
    {
        return new Reservation
        {
            roomId = dto.roomId,
            organizerName =  dto.organizerName,
            topic =  dto.topic,
            startTime = dto.startTime,
            endTime = dto.endTime,
            status = ConvertStringToStatus(dto.status)
        };
    }
    
    public static ReservationDTO ToDto(this Reservation reservation)
    {
        return new ReservationDTO
        {
            Id = reservation.Id,
            roomId = reservation.roomId,
            organizerName =  reservation.organizerName,
            topic =  reservation.topic,
            startTime = reservation.startTime,
            endTime = reservation.endTime,
            status = ConvertStatusToString(reservation.status)
        };
    }

    private static ReservationStatus ConvertStringToStatus(string status) {
        return status switch {
            "Cancelled" => ReservationStatus.Cancelled,
            "Planned" => ReservationStatus.Planned,
            "Confirmed" => ReservationStatus.Confirmed,
            "Free" => ReservationStatus.Free,
            _ => ReservationStatus.Unknown
        };
    }

    private static string ConvertStatusToString(ReservationStatus status) {
        return status switch {
            ReservationStatus.Cancelled => "Cancelled",
            ReservationStatus.Planned => "Planned",
            ReservationStatus.Confirmed => "Confirmed",
            ReservationStatus.Free => "Free",
            _ => "Unknown"
        };
    }
    
    
}