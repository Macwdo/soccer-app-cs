using AutoMapper;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Player;

namespace WebApiDotnet.Mappers;

public class PlayerProfile: BaseProfile<PlayerEntity, PlayerRequest, PlayerResponse> {}