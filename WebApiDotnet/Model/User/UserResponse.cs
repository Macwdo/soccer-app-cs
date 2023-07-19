using System.ComponentModel.DataAnnotations;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Model;

public class UserResponse
{
    public string? Id { get; set; }
    public string? Username { get; set; }

    public string? Email { get; set; }
    
    public UserType UserType { get; set; }
    
    public bool Active { get; set; }
}
