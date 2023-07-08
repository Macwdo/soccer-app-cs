using Hangfire;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories;
using ILogger = Serilog.ILogger;

namespace WebApiDotnet.Controllers;

public class UserController: Controller
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger _logger;

    public UserController(
        IUserRepository userRepository,
        ILogger logger
        )
    {
        _userRepository = userRepository;
        _logger = logger;
    }


    [HttpPost, Route("/users")]
    public async Task<IActionResult> Create([FromBody] User user)
    { 
        var newUser = await _userRepository.Add(user);
        return Ok(newUser);

    }

    [HttpGet, Route("/users")]
    public async Task<IActionResult> Get()
    {
        BackgroundJob.Enqueue(() => Console.WriteLine("Enqueued at rabbit"));
        var users = await _userRepository.Find();
        return Ok(users);
    }

    [HttpGet, Route("/user/{guid}")]
    public async Task<IActionResult> Get(Guid guid)
    {
        var user = await _userRepository.Find(guid);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPut, Route("/user/{guid}")]
    public async Task<IActionResult> Update(Guid guid, [FromBody] User user)
    {
        var userEdited =  await _userRepository.Edit(guid, user);
        if (userEdited == null)
            return NotFound();
        return Ok(userEdited);
    }

    [HttpDelete, Route("/user/{guid}")]
    public async Task<IActionResult> Delete(Guid guid)
    {
        var user = await _userRepository.Delete(guid);
        if (!user)
            return NotFound();
        return NoContent();
    }
    
}