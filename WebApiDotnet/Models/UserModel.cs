namespace WebApiDotnet.Models;


public enum UserType
{
    Admin, Player
}

public class User: BaseEntity
{
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public string? Email { get; set; }
    public string? Password { get; set; }

    public UserType UserType { get; set; }
}
