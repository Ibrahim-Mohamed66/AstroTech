using AstroTech.BLL.Contracts;
using AstroTech.BLL.DTOs;
using AstroTech.DAL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
namespace AstroTech.BLL.Services;


public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly string _profileImagesPath;

    public UserService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
    {
        _unitOfWork = unitOfWork;
        _profileImagesPath = Path.Combine(env.WebRootPath, "img", "profile");

        if (!Directory.Exists(_profileImagesPath))
        {
            Directory.CreateDirectory(_profileImagesPath);
        }
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
            throw new ArgumentNullException(nameof(loginDto));

        var user = await _unitOfWork.Users.GetUserByEmailAsync(loginDto.Email);
        if (user == null)
            return SignInResult.Failed;

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
            throw new ArgumentNullException(nameof(registerDto));

        var existingUser = await _unitOfWork.Users.GetUserByEmailAsync(registerDto.Email);
        if (existingUser != null)
        {
            return IdentityResult.Failed(new IdentityError
            {
                Description = "User with this email already exists."
            });
        }

        var result = await _unitOfWork.Users.CreateUserAsync(
            registerDto.Email,
            registerDto.Password,
            registerDto.FirstName,
            registerDto.LastName,
            registerDto.PhoneNumber
        );

        return result;
    }

    public async Task<UpdateProfileDTO?> GetProfileAsync(int userId)
    {
        var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
        if (user == null) return null;

        return new UpdateProfileDTO
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            ProfileImage = user.ProfileImage
        };
    }

    public async Task<IdentityResult> UpdateProfileAsync(int userId, UpdateProfileDTO model, IFormFile? profileImageFile = null, bool removeProfileImage = false)
    {
        var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
        if (user == null)
        {
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        }

        // Update user properties
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.Email = model.Email;
        user.PhoneNumber = model.PhoneNumber;

        // Handle profile image
        if (removeProfileImage)
        {
            // Delete the old image file if it exists
            if (!string.IsNullOrEmpty(user.ProfileImage))
            {
                var oldImagePath = Path.Combine(_profileImagesPath, user.ProfileImage);
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }
            user.ProfileImage = null;
        }
        else if (profileImageFile != null && profileImageFile.Length > 0)
        {
            // Delete the old image if it exists
            if (!string.IsNullOrEmpty(user.ProfileImage))
            {
                var oldImagePath = Path.Combine(_profileImagesPath, user.ProfileImage);
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }

            // Generate a unique filename for the new image
            string fileExtension = Path.GetExtension(profileImageFile.FileName);
            string newFileName = $"{userId}_{DateTime.Now.Ticks}{fileExtension}";
            string filePath = Path.Combine(_profileImagesPath, newFileName);

            // Save the new image
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await profileImageFile.CopyToAsync(stream);
            }

            // Update user with new image filename
            user.ProfileImage = newFileName;
        }

        // Handle password change if provided
        if (!string.IsNullOrWhiteSpace(model.CurrentPassword) && !string.IsNullOrWhiteSpace(model.NewPassword))
        {
            if (model.NewPassword.Length < 8)
            {
                return IdentityResult.Failed(new IdentityError { Description = "New password must be at least 8 characters." });
            }

            var passwordCheck = await _unitOfWork.Users.CheckPasswordAsync(user, model.CurrentPassword);
            if (!passwordCheck)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Current password is incorrect." });
            }

            var result = await _unitOfWork.Users.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                return result;
            }
        }

        return await _unitOfWork.Users.UpdateUserAsync(user);
    }

}
