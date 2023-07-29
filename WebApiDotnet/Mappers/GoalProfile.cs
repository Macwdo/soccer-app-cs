using AutoMapper;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Goal;

namespace WebApiDotnet.Mappers;

public class GoalProfile: BaseProfile<GoalEntity, GoalRequest, GoalResponse> {}