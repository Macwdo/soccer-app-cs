using System.ComponentModel.DataAnnotations;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Model;

public class UserResponse
{
    public string Id { get; set; } = null!;
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;
    
    public UserType UserType { get; set; }
    
    public bool Active { get; set; }
}
