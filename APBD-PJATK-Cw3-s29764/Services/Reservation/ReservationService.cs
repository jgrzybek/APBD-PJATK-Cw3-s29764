using APBD_PJATK_Cw3_s29764.DTOs.Reservation;
using APBD_PJATK_Cw3_s29764.Enums;
using APBD_PJATK_Cw3_s29764.Exceptions;
using APBD_PJATK_Cw3_s29764.mappers;
using APBD_PJATK_Cw3_s29764.Repositories;

namespace APBD_PJATK_Cw3_s29764.Services.Reservation;

public class ReservationService(IReservationRepository reservationRepository, IRoomRepository roomRepository) : IReservationService
{
    public IEnumerable<ReservationDTO> GetAll()
    {
        return reservationRepository.GetAll()
            .Select(reservation => reservation.ToDto());
    }

    public ReservationDTO GetById(int id)
    {
        var tmpReservation = reservationRepository.GetById(id);
        return tmpReservation is not null
            ? tmpReservation.ToDto()
            : throw new ObjectNotInRepositoryException(id);
    }

    public ReservationDTO Add(CreateReservationDTO reservation)
    {
        var reservationToAdd = reservation.ToDomain();
        
        var room = roomRepository.GetById(reservationToAdd.roomId);
        if (room == null)
            throw new InvalidOperationException($"Sala o ID {reservationToAdd.roomId} nie istnieje.");

        if (!room.isActive)
            throw new InvalidOperationException($"Nie można zarezerwować nieaktywnej sali (ID: {reservationToAdd.roomId}).");
        
        var conflicting = reservationRepository
            .GetAll()
            .Any(r => r.roomId == reservationToAdd.roomId &&
                      r.status != ReservationStatus.Cancelled &&
                      r.startTime < reservationToAdd.endTime &&
                      r.endTime > reservationToAdd.startTime);

        if (conflicting)
            throw new ReservationConflictException("Rezerwacja nakłada się z inną istniejącą rezerwacją tej sali.");

        reservationRepository.Add(reservationToAdd);
        return reservationToAdd.ToDto();
    }

    public ReservationDTO Update(int id, UpdateReservationDTO reservation)
    {
        var tmpReservation = reservation.ToDomain();
        tmpReservation.Id = id;

        return !reservationRepository.Update(tmpReservation) 
            ? throw new ObjectNotInRepositoryException(id) 
            : tmpReservation.ToDto();
    }

    public void Remove(int id)
    {
        var tmpReservation = reservationRepository.GetById(id);
        
        if (tmpReservation is null)
        {
            throw new ObjectNotInRepositoryException(id);
        }
        
        reservationRepository.Remove(tmpReservation);
    }
}