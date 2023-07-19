using Microsoft.AspNetCore.Identity;

namespace WebApiDotnet.Entities;


public enum UserType
{
    Admin,
    Player
}

public class UserEntity: IdentityUser
{
    // One to One -> User -> Player
    public PlayerEntity? Player {get; set;}
    public UserType UserType { get; set; }
}
