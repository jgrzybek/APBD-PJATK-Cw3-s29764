using APBD_PJATK_Cw3_s29764.DTOs.Reservation;
using APBD_PJATK_Cw3_s29764.Exceptions;
using APBD_PJATK_Cw3_s29764.mappers;
using APBD_PJATK_Cw3_s29764.Repositories;

namespace APBD_PJATK_Cw3_s29764.Services.Reservation;

public class ReservationService(IReservationRepository repository) : IReservationService
{
    public IEnumerable<ReservationDTO> GetAll()
    {
        return repository.GetAll()
            .Select(reservation => reservation.ToDto());
    }

    public ReservationDTO GetById(int id)
    {
        var tmpReservation = repository.GetById(id);
        return tmpReservation is not null
            ? tmpReservation.ToDto()
            : throw new ObjectNotInRepositoryException(id);
    }

    public ReservationDTO Add(CreateReservationDTO reservation)
    {
        var reservationToAdd = reservation.ToDomain();
        repository.Add(reservationToAdd);
        
        return reservationToAdd.ToDto();
    }

    public ReservationDTO Update(int id, UpdateReservationDTO reservation)
    {
        var tmpReservation = reservation.ToDomain();
        tmpReservation.Id = id;

        return !repository.Update(tmpReservation) 
            ? throw new ObjectNotInRepositoryException(id) 
            : tmpReservation.ToDto();
    }

    public void Remove(int id)
    {
        var tmpReservation = repository.GetById(id);
        
        if (tmpReservation is null)
        {
            throw new ObjectNotInRepositoryException(id);
        }
        
        repository.Remove(tmpReservation);
    }
}