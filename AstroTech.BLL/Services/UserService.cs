using AstroTech.BLL.Contracts;
using AstroTech.BLL.DTOs;
using AstroTech.DAL.Contracts;
using Microsoft.AspNetCore.Identity;


namespace AstroTech.BLL.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;


    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDTO?> GetUser(int id)
    {
        var user = await _unitOfWork.Users.GetUserByIdAsync(id);
        if (user == null)
        {
            return null;
        }
        return new UserDTO
        {
            Id = user.Id,
            FullName = $"{user.FirstName} {user.LastName} ",
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };

    }


    public async Task<SignInResult> LoginAsync(LoginDTO loginDto)
    {
        if (loginDto == null)
        {
            throw new ArgumentNullException(nameof(loginDto));
        }
        var user = await _unitOfWork.Users.GetUserByEmailAsync(loginDto.Email);
        if (user == null)
        {
            return SignInResult.Failed;
        }
        var result = await _unitOfWork.Users.SignInAsync(user.Email, loginDto.Password, loginDto.RememberMe);
        return result;
    }


    public async Task LogoutAsync()
    {
        await _unitOfWork.Users.SignOutAsync();
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDTO registerDto)
    {
        if (registerDto == null)
        {
            throw new ArgumentNullException(nameof(registerDto));
        }

        // Check if user already exists by email
        var existingUser = await _unitOfWork.Users.GetUserByEmailAsync(registerDto.Email);
        if (existingUser != null)
        {
            return IdentityResult.Failed(new IdentityError { Description = "User with this email already exists." });
        }

        // Use repository method that accepts basic data instead of domain model
        var result = await _unitOfWork.Users.CreateUserAsync(registerDto.Email, registerDto.Password, registerDto.FirstName,
                                                               registerDto.LastName, registerDto.PhoneNumber);
        return result;
    }

}
