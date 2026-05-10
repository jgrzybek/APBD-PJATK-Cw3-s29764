using System.ComponentModel.DataAnnotations;

namespace APBD_PJATK_Cw3_s29764.DTOs.Reservation;

public class UpdateReservationDTO
{
    [Required]
    public int roomId { get; set; }
    [MinLength(1), MaxLength(50),  Required]
    public string organizerName { get; set; } = string.Empty;
    [MinLength(1), MaxLength(50),  Required]
    public string topic { get; set; } = string.Empty;
    [Required]
    public DateTime startTime { get; set; }
    [CustomValidation(typeof(UpdateReservationDTO), nameof(ValidateEndTimeGreaterThanStartTime)), Required]
    public DateTime endTime { get; set; }
    [Required]
    public string status { get; set; } =  string.Empty;
    
    public ValidationResult? ValidateEndTimeGreaterThanStartTime(DateTime endTime, ValidationContext context)
    {
        var instance = (UpdateReservationDTO)context.ObjectInstance;
            
        return endTime <= instance.startTime
            ? new ValidationResult("Czas zakończenia musi być późniejszy niż czas rozpoczęcia.")
            : ValidationResult.Success;
    }
}