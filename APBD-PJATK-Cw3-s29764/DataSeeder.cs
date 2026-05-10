using APBD_PJATK_Cw3_s29764.Enums;
using APBD_PJATK_Cw3_s29764.Models;
using APBD_PJATK_Cw3_s29764.Repositories;


namespace APBD_PJATK_Cw3_s29764;

public static class DataSeeder
{

    public static void Seed(IRoomRepository roomRepo, IReservationRepository reservationRepo)
    {
        roomRepo.Add(new Room 
        { 
            Name = "Sala A1", 
            buildingCode = "A", 
            floor = 1, 
            capacity = 30, 
            hasProjector = true, 
            isActive = true 
        });

        roomRepo.Add(new Room 
        { 
            Name = "Sala A2", 
            buildingCode = "A", 
            floor = 2, 
            capacity = 50, 
            hasProjector = true, 
            isActive = true 
        });

        roomRepo.Add(new Room 
        { 
            Name = "Sala B1", 
            buildingCode = "B", 
            floor = 1, 
            capacity = 20, 
            hasProjector = false, 
            isActive = true 
        });

        roomRepo.Add(new Room 
        { 
            Name = "Sala C3", 
            buildingCode = "C", 
            floor = 3, 
            capacity = 80, 
            hasProjector = true, 
            isActive = true 
        });

        roomRepo.Add(new Room 
        { 
            Name = "Sala D1", 
            buildingCode = "D", 
            floor = 1, 
            capacity = 25, 
            hasProjector = true, 
            isActive = false 
        });
        
        
        var rooms = roomRepo.GetAll().ToList();

        reservationRepo.Add(new Reservation
        {
            roomId = rooms[0].Id,
            startTime = DateTime.Now.AddDays(1).AddHours(9),
            endTime = DateTime.Now.AddDays(1).AddHours(11),
            organizerName = "Jan Kowalski",
            topic = "Spotkanie zespołu projektowego",
            status = ReservationStatus.Confirmed
        });

        reservationRepo.Add(new Reservation
        {
            roomId = rooms[1].Id,
            startTime = DateTime.Now.AddDays(2).AddHours(10),
            endTime = DateTime.Now.AddDays(2).AddHours(12),
            organizerName = "Anna Nowak",
            topic = "Wykład gościnny",
            status = ReservationStatus.Confirmed
        });

        reservationRepo.Add(new Reservation
        {
            roomId = rooms[2].Id,
            startTime = DateTime.Now.AddDays(1).AddHours(14),
            endTime = DateTime.Now.AddDays(1).AddHours(16),
            organizerName = "Piotr Zieliński",
            topic = "Prezentacja produktu",
            status = ReservationStatus.Planned
        });
        
        reservationRepo.Add(new Reservation
        {
            roomId = rooms[3].Id,
            startTime = DateTime.Now.AddDays(3).AddHours(13),
            endTime = DateTime.Now.AddDays(3).AddHours(15),
            organizerName = "Katarzyna Wiśniewska",
            topic = "Szkolenie dla działu sprzedaży",
            status = ReservationStatus.Confirmed
        });

        reservationRepo.Add(new Reservation
        {
            roomId = rooms[1].Id,
            startTime = DateTime.Now.AddDays(4).AddHours(8),
            endTime = DateTime.Now.AddDays(4).AddHours(10),
            organizerName = "Marek Lewandowski",
            topic = "Warsztaty z programowania",
            status = ReservationStatus.Confirmed
        });
    }
}