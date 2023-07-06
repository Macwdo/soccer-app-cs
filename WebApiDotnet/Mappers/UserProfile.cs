using AutoMapper;
using WebApiDotnet.Models;

namespace WebApiDotnet.Mappers;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<User, User>();
    }
}