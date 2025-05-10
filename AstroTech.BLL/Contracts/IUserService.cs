using AstroTech.BLL.DTOs;
using Microsoft.AspNetCore.Identity;
namespace AstroTech.BLL.Contracts;
public interface IUserService
{
    Task<SignInResult> LoginAsync(LoginDTO loginDto);
    Task<IdentityResult> RegisterAsync(RegisterDTO registerDto);
    Task LogoutAsync();
    Task<UserDTO> GetUser(int id);
}
