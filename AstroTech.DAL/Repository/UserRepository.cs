using AstroTech.Domain.Models;
using AstroTech.Infrastructure.Contracts;
using Microsoft.AspNetCore.Identity;


namespace AstroTech.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<int>> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<IdentityResult> CreateUserAsync(string email, string password, string firstName, string lastName, string phoneNumber)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber
        };

        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole<int> { Name = "User" });
            }
            await _userManager.AddToRoleAsync(user, "User");
            await _signInManager.SignInAsync(user, isPersistent: false);
        }
        return result;
    }
    public async Task<IdentityResult> UpdateProfile(string email, string password, string firstName, string lastName, string phoneNumber)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        }
        user.FirstName = firstName;
        user.LastName = lastName;
        user.PhoneNumber = phoneNumber;
        if (!string.IsNullOrEmpty(password))
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, password);
            if (!result.Succeeded)
            {
                return result;
            }
        }
        return await _userManager.UpdateAsync(user);
    }



    public async Task<ApplicationUser> GetUserByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user;
    }

    public async Task<ApplicationUser> GetUserByIdAsync(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        return user;
    }

    
    public async Task<SignInResult> SignInAsync(string email, string password, bool rememberMe)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return SignInResult.Failed;
        }

        return await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
