using System.ComponentModel.DataAnnotations;

namespace APBD_PJATK_Cw3_s29764.DTOs.Reservation;

public class CreateReservationDTO
{
    [Required]
    int roomId { get; set; }
    [MinLength(1), MaxLength(50),  Required]
    string organizerName { get; set; } = string.Empty;
    [MinLength(1), MaxLength(50),  Required]
    string topic { get; set; } = string.Empty;
    [Required]
    DateTime startTime { get; set; }
    [CustomValidation(typeof(CreateReservationDTO), nameof(ValidateEndTimeGreaterThanStartTime)), Required]
    DateTime endTime { get; set; }
    [Required]
    string status { get; set; } =  string.Empty;
    
    public static ValidationResult? ValidateEndTimeGreaterThanStartTime(DateTime endTime, ValidationContext context)
    {
        var instance = (CreateReservationDTO)context.ObjectInstance;
            
        return endTime <= instance.startTime
            ? new ValidationResult("Czas zakończenia musi być późniejszy niż czas rozpoczęcia.")
            : ValidationResult.Success;
    }
}