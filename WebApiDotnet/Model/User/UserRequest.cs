using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Model;

public class UserRequest
{
    [Required, MaxLength(30)]
    public string Username { get; set; } = null!;

    [Required, EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required, MinLength(8)]
    public string Password { get; set; } = null!;
    
    [Required]
    public UserType UserType { get; set; }
}
