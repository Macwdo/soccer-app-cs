using AutoMapper;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Game;

namespace WebApiDotnet.Mappers;

public class GameProfile: BaseProfile<GameEntity, GameRequest, GameResponse> {}