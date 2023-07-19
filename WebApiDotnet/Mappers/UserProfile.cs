using AutoMapper;
using WebApiDotnet.Entities;
using WebApiDotnet.Model;

namespace WebApiDotnet.Mappers;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, UserRequest>().ReverseMap();
        CreateMap<UserEntity, UserResponse>().ReverseMap();
    }
}