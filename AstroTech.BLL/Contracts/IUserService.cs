using AstroTech.BLL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
namespace AstroTech.BLL.Contracts;
public interface IUserService
{
    Task<SignInResult> LoginAsync(LoginDTO loginDto);
    Task<IdentityResult> RegisterAsync(RegisterDTO registerDto);
    Task<UpdateProfileDTO> GetProfileAsync(int userId);
    Task<IdentityResult> UpdateProfileAsync(int userId, UpdateProfileDTO model, IFormFile? profileImageFile = null, bool removeProfileImage = false);

    Task LogoutAsync();
    Task<UserDTO> GetUser(int id);
}
