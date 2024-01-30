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
    public string Mobile { get; set; } = string.Empty;
    
    public bool IsArchived { get; set; }
    public DateTime? ArchivedDate { get; set; }
}
