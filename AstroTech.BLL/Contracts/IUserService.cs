using AstroTech.Application.DTOs;
using Microsoft.AspNetCore.Identity;
namespace AstroTech.Application.Contracts;
public interface IUserService
{
    Task<SignInResult> LoginAsync(LoginDTO loginDto);
    Task<IdentityResult> RegisterAsync(RegisterDTO registerDto);
    Task LogoutAsync();
    Task<UserDTO> GetUser(int id);
}
