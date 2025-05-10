using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroTech.BLL.DTOs;
public class RegisterDTO
{
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 50 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 50 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [StringLength(100, ErrorMessage = "Email address is too long.")]
    [Display(Name = "Email Address")]
    public string Email { get; set; }
    [Required]
    [StringLength(14, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    [DataType(DataType.Password)]

    public string Password { get; set; }
    [Required]
    [StringLength(14, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }
    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be exactly 11 digits.")]
    public string PhoneNumber { get; set; }
}
