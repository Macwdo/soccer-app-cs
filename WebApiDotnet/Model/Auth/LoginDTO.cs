using System.ComponentModel.DataAnnotations;
namespace WebApiDotnet.Model;

public class LoginDTO
{

    [Required, MaxLength(30)]
    public string? Username { get; set; }

    [Required]
    public string? Email { get; set; }
    
    [Required]
    public string? Password { get; set; }

}