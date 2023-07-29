using AutoMapper;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Goal;

namespace WebApiDotnet.Mappers;

public class GoalProfile: Profile
{
    public GoalProfile()
    {
        CreateMap<GoalRequest, GoalEntity>().ReverseMap();
    }
}