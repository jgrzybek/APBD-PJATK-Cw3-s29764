using System.ComponentModel.DataAnnotations;

namespace APBD_PJATK_Cw3_s29764.DTOs.Reservation;

public class CreateReservationDTO
{
    [Required]
    public int roomId { get; set; }
    [MinLength(1), MaxLength(50),  Required]
    public string organizerName { get; set; } = string.Empty;
    [MinLength(1), MaxLength(50),  Required]
    public string topic { get; set; } = string.Empty;
    [Required]
    public DateTime startTime { get; set; }
    [CustomValidation(typeof(CreateReservationDTO), nameof(ValidateEndTimeGreaterThanStartTime)), Required]
    public DateTime endTime { get; set; }
    [Required, AllowedValues("Planned", "Confirmed", "Cancelled", "Free")]
    public string status { get; set; } =  string.Empty;
    
    public static ValidationResult? ValidateEndTimeGreaterThanStartTime(DateTime endTime, ValidationContext context)
    {
        var instance = (CreateReservationDTO)context.ObjectInstance;
            
        return endTime <= instance.startTime
            ? new ValidationResult("Czas zakończenia musi być późniejszy niż czas rozpoczęcia.")
            : ValidationResult.Success;
    }
}