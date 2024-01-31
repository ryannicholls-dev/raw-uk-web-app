using System.ComponentModel.DataAnnotations;

namespace RAW_UK.UI;

public class SignUpViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Mobile Number")]
    [RegularExpression(@"^\+?[0-9]+$", ErrorMessage = "Invalid mobile number.")]
    [MaxLength(11, ErrorMessage = "Mobile number must be 11 numbers long")]
    [MinLength(11, ErrorMessage = "Mobile number must be 11 numbers long")]
    public string Mobile { get; set; } = string.Empty;
    
    public bool IsArchived { get; set; }
    public DateTime? ArchivedDate { get; set; }
}
