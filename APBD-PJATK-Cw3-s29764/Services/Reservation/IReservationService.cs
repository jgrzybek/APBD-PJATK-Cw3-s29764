using APBD_PJATK_Cw3_s29764.DTOs.Reservation;

namespace APBD_PJATK_Cw3_s29764.Services.Reservation;

public interface IReservationService
{
    IEnumerable<ReservationDTO> GetAll();
    ReservationDTO GetById(int id);
    ReservationDTO Add(CreateReservationDTO reservation);
    ReservationDTO Update(int id, UpdateReservationDTO reservation);
    void Remove(int id);
}