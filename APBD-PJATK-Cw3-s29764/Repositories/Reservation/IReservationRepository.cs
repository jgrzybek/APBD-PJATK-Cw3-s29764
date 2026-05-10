using APBD_PJATK_Cw3_s29764.Models;

namespace APBD_PJATK_Cw3_s29764.Repositories;

public interface IReservationRepository
{
    IEnumerable<Reservation> GetAll(); 
    Reservation? GetById(int id);
    void Add(Reservation reservation);
    bool Update(Reservation reservation);
    void Remove(Reservation reservation);
    bool Exists(int id);
}