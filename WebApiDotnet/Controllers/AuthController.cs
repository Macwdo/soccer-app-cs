using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Auth;
using WebApiDotnet.Services;

namespace WebApiDotnet.Controllers;

[ApiController]
public class AuthController : Controller
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IConfiguration _configuration;
        
    public AuthController(
        UserManager<UserEntity> userManager,
        IConfiguration configuration
    )
    {
        _configuration = configuration;
        _userManager = userManager;
    }
        
    [HttpPost, Route("auth/login/")] // Admin
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);
        if (user == null)
            return NotFound();

        var result = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

        if (!result)
            return BadRequest(new { detail = "Incorrect password" });

        var service = new LoginService(_configuration, _userManager, user);
        var token = await service.CreateTokenAsync();
            
        return Ok(token);

    } 
}