namespace RAW_UK.Model;

/// <summary>
/// Model for capturing sign up information
/// </summary>
public class SignUp : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
}
