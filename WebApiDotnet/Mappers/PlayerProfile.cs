using AutoMapper;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Player;

namespace WebApiDotnet.Mappers;

public class PlayerProfile: Profile
{
    public PlayerProfile()
    {
        CreateMap<PlayerEntity, PlayerRequest>().ReverseMap();
        CreateMap<PlayerEntity, PlayerResponse>().ReverseMap();

    }
    
}