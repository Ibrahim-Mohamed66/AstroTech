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
    Task<IdentityResult> UpdateProfile(string email, string password, string firstName, string lastName, string phoneNumber);

}