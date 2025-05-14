using Microsoft.AspNetCore.Http;

public class UpdateProfileDTO
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? CurrentPassword { get; set; }
    public string? NewPassword { get; set; }
    public IFormFile? ProfileImageFile { get; set; } 
    public string? ProfileImage { get; set; }       
    public bool RemoveProfileImage { get; set; }

}
