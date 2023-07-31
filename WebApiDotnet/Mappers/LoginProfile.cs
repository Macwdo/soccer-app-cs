using AutoMapper;
using WebApiDotnet.Model;
using WebApiDotnet.Model.Auth;

namespace WebApiDotnet.Mappers;

public class LoginProfile: Profile
{
    public LoginProfile()
    {
        CreateMap<UserRequest, LoginRequest>().ReverseMap();
    }
    
}