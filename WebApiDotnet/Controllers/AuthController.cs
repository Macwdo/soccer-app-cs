using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Entities;
using WebApiDotnet.Model;
using WebApiDotnet.Services;

namespace WebApiDotnet.Controllers;

public class AuthController : ControllerBase
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
    public async Task<IActionResult> Login(LoginDTO loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
            return NotFound();

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

        if (!result)
            return BadRequest(new { detail = "Incorrect password" });

        var service = new LoginService(_configuration, _userManager, user);
        var token = await service.CreateTokenAsync();
            
        return Ok(token);

    } 
}