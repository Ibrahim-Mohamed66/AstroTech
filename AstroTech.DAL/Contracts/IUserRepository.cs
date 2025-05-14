using AstroTech.DAL.Models;
using Microsoft.AspNetCore.Identity;
namespace AstroTech.DAL.Contracts;
public interface IUserRepository
{
    Task<ApplicationUser> GetUserByIdAsync(int id);
    Task<ApplicationUser> GetUserByEmailAsync(string email);
    Task<SignInResult> SignInAsync(string email, string password, bool rememberMe);
    Task<IdentityResult> CreateUserAsync(string email, string password, string firstName, string lastName, string phoneNumber);
    Task SignOutAsync();
    Task<IdentityResult> UpdateProfile(string email, string password, string firstName, string lastName, string phoneNumber,string ProfileImage = null);
    Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
    Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
    Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);
    Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
}