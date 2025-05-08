using AstroTech.Application.Contracts;
using AstroTech.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AstroTech.Controllers;
public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginDTO model)
    {
        if(!ModelState.IsValid)
            return View(model);
        var result = await _userService.LoginAsync(model);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }
        ModelState.AddModelError(string.Empty, "Invalid email or password.");
        return View(model);
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterDTO Model)
    {
        if (!ModelState.IsValid)
            return View(Model);
        var result = await _userService.RegisterAsync(Model);
        if (result.Succeeded)
        {
            return RedirectToAction("Login");
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(Model);
    }

    public async Task<IActionResult> Logout()
    {
        await _userService.LogoutAsync();
        return RedirectToAction("Login");
    }
    [HttpGet]
    [Authorize]
    public IActionResult UpdateProfile()
    {
 
        return View();
    }

}