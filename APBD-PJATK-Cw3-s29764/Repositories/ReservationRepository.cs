using APBD_PJATK_Cw3_s29764.Models;

namespace APBD_PJATK_Cw3_s29764.Repositories;

public class ReservationRepository
{
    private static int _nextId = 1;
    private readonly List<Reservation> _reservations = [];
    
    public IEnumerable<Reservation> GetAll()
    {
        return _reservations;
    }

    public Reservation? GetById(int id)
    {
        return _reservations.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Reservation reservation)
    {
        reservation.Id = _nextId++;
        _reservations.Add(reservation);
    }

    public bool Update(Reservation reservation)
    {
        var existing = GetById(reservation.Id);
        if (existing is null)
        {
            return false;
        }
        
        existing.roomId = reservation.roomId;
        existing.startTime = reservation.startTime;
        existing.organizerName = reservation.organizerName;
        existing.topic =  reservation.topic;
        existing.endTime = reservation.endTime;
        existing.status = reservation.status;
        
        return true;
    }

    public void Remove(Reservation reservation)
    {
        _reservations.Remove(reservation);
    }

    public bool Exists(int id)
    {
        return _reservations.Any(x => x.Id == id);
    }
}