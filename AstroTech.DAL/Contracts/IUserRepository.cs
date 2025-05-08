using AstroTech.Domain.Models;
using Microsoft.AspNetCore.Identity;
namespace AstroTech.Infrastructure.Contracts;
public interface IUserRepository
{
    Task<ApplicationUser> GetUserByIdAsync(int id);
    Task<ApplicationUser> GetUserByEmailAsync(string email);
    Task<SignInResult> SignInAsync(string email, string password, bool rememberMe);
    Task<IdentityResult> CreateUserAsync(string email, string password, string firstName, string lastName, string phoneNumber);
    Task SignOutAsync();
    Task<IdentityResult> UpdateProfile(string email, string password, string firstName, string lastName, string phoneNumber);

}