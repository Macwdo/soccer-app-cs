using AutoMapper;
using WebApiDotnet.Model;

namespace WebApiDotnet.Mappers;

public class LoginProfile: Profile
{
    public LoginProfile()
    {
        CreateMap<UserRequest, LoginDTO>().ReverseMap();
    }
    
    
}