using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Models;
namespace WebApiDotnet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<UserModel>> GetAllUsers()
    {
        return Ok();
    }
}