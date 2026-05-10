using System.ComponentModel.DataAnnotations;
using APBD_PJATK_Cw3_s29764.Enums;

namespace APBD_PJATK_Cw3_s29764.DTOs.Reservation;

public class ReservationDTO
{
    public int Id { get; set; }
    public int roomId { get; set; }
    public string organizerName { get; set; } = string.Empty;
    public string topic { get; set; } = string.Empty;
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    [AllowedValues("Planned", "Confirmed", "Cancelled")]
    public string status { get; set; }
}