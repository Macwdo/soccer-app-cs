using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Entities;
using WebApiDotnet.Model;
using ILogger = Serilog.ILogger;

namespace WebApiDotnet.Controllers;

public class UserController: Controller
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly UserManager<UserEntity> _userManager;

    public UserController(
        ILogger logger,
        UserManager<UserEntity> userManager,
        IMapper mapper
            )
    {
        _mapper = mapper;
        _userManager = userManager;
        _logger = logger;
    }

    
    [HttpPost, Route("user")] // Admin
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<IdentityError>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Create([FromBody] UserRequest userRequest)
    { 
        var user = _mapper.Map<UserEntity>(userRequest);
        var result = await _userManager.CreateAsync(user, userRequest.Password);
        if (result.Succeeded)
        {
            var userResponse = _mapper.Map<UserResponse>(user);
            return Ok(userResponse);
        }

        return BadRequest(result.Errors);

    }

    [HttpGet, Route("users"), AllowAnonymous]
    public IActionResult Get()
    {
        var users = _mapper.Map<List<UserResponse>>(_userManager.Users);
        return Ok(users);
    }

    [HttpGet, Route("user/{id}"), AllowAnonymous]
    public async Task<IActionResult> Get(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return NotFound();
        var userResponse = _mapper.Map<UserResponse>(user);
        return Ok(userResponse);
    }

    [HttpPut, Route("user/{id}")]  // Admin
    public async Task<IActionResult> Update(string id, [FromBody] UserRequest userRequest)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return NotFound();
        
        var userMap = _mapper.Map<UserEntity>(userRequest);
        await _userManager.UpdateAsync(userMap);
        var userResponse = _mapper.Map<UserResponse>(userMap);
        
        return Ok(userResponse);
    }

    [HttpDelete, Route("user/{id}")] // Admin
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return NotFound();
        await _userManager.DeleteAsync(user);
        return NoContent();
    }
    
}
